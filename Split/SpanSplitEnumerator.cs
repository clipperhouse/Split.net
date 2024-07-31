// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/runtime/blob/main/LICENSE.TXT

// This is the Microsoft implementation from .Net 9.0, intended as a backport for .Net 8.0

using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Split;

/// <summary>
/// Enables enumerating each split within a <see cref="ReadOnlySpan{T}"/> that has been divided using one or more separators.
/// </summary>
internal ref partial struct SpanSplitEnumerator<T> where T : IEquatable<T>
{
    /// <summary>The input span being split.</summary>
    internal ReadOnlySpan<T> input;

    /// <summary>A single separator to use when <see cref="mode"/> is <see cref="SpanSplitEnumeratorMode.SingleElement"/>.</summary>
    private readonly T separator = default!;
    /// <summary>
    /// A separator span to use when <see cref="mode"/> is <see cref="SpanSplitEnumeratorMode.Sequence"/> (in which case
    /// it's treated as a single separator) or <see cref="SpanSplitEnumeratorMode.Any"/> (in which case it's treated as a set of separators).
    /// </summary>
    private readonly ReadOnlySpan<T> separators;
    /// <summary>A set of separators to use when <see cref="mode"/> is <see cref="SpanSplitEnumeratorMode.SearchValues"/>.</summary>
    private readonly SearchValues<T> searchValues = default!;

    /// <summary>Mode that dictates how the instance was configured and how its fields should be used in <see cref="MoveNext"/>.</summary>
    private readonly SpanSplitEnumeratorMode mode;
    /// <summary>The inclusive starting index in <see cref="input"/> of the current range.</summary>
    internal int start = 0;
    /// <summary>The exclusive ending index in <see cref="input"/> of the current range.</summary>
    internal int end = 0;
    /// <summary>The index in <see cref="input"/> from which the next separator search should start.</summary>
    ///
    public readonly int Position => cursor;
    private int cursor = 0;
    private bool done = false;

    /// <summary>Gets an enumerator that allows for iteration over the split span.</summary>
    /// <returns>Returns a <see cref="SpanSplitEnumerator{T}"/> that can be used to iterate over the split span.</returns>
    public SpanSplitEnumerator<T> GetEnumerator() => this;

    /// <summary>Gets the current element of the enumeration.</summary>
    /// <returns>Returns a <see cref="Range"/> instance that indicates the bounds of the current element withing the source span.</returns>
    public Range Current => new Range(start, end);

    /// <summary>Initializes the enumerator for <see cref="SpanSplitEnumeratorMode.SearchValues"/>.</summary>
    internal SpanSplitEnumerator(ReadOnlySpan<T> input, SearchValues<T> searchValues)
    {
        this.input = input;
        mode = SpanSplitEnumeratorMode.SearchValues;
        this.searchValues = searchValues;
    }

    /// <summary>Initializes the enumerator for <see cref="SpanSplitEnumeratorMode.Any"/>.</summary>
    /// <remarks>
    /// If <paramref name="separators"/> is empty and <typeparamref name="T"/> is <see cref="char"/>, as an optimization
    /// it will instead use <see cref="SpanSplitEnumeratorMode.SearchValues"/> with a cached <see cref="SearchValues{Char}"/>
    /// for all whitespace characters.
    /// </remarks>
    internal SpanSplitEnumerator(ReadOnlySpan<T> input, ReadOnlySpan<T> separators)
    {
        this.input = input;
        this.separators = separators;
        mode = SpanSplitEnumeratorMode.Any;
    }

    /// <summary>Initializes the enumerator for <see cref="SpanSplitEnumeratorMode.Sequence"/> (or <see cref="SpanSplitEnumeratorMode.EmptySequence"/> if the separator is empty).</summary>
    /// <remarks><paramref name="treatAsSingleSeparator"/> must be true.</remarks>
    internal SpanSplitEnumerator(ReadOnlySpan<T> input, ReadOnlySpan<T> separator, bool treatAsSingleSeparator)
    {
        Debug.Assert(treatAsSingleSeparator, "Should only ever be called as true; exists to differentiate from separators overload");

        this.input = input;
        separators = separator;
        mode = separator.Length == 0 ?
            SpanSplitEnumeratorMode.EmptySequence :
            SpanSplitEnumeratorMode.Sequence;
    }

    /// <summary>Initializes the enumerator for <see cref="SpanSplitEnumeratorMode.SingleElement"/>.</summary>
    internal SpanSplitEnumerator(ReadOnlySpan<T> input, T separator)
    {
        this.input = input;
        this.separator = separator;
        mode = SpanSplitEnumeratorMode.SingleElement;
    }

    /// <summary>
    /// Advances the enumerator to the next element of the enumeration.
    /// </summary>
    /// <returns><see langword="true"/> if the enumerator was successfully advanced to the next element; <see langword="false"/> if the enumerator has passed the end of the enumeration.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        if (done)
        {
            return false;
        }

        // Search for the next separator index.
        int separatorIndex, separatorLength;
        switch (mode)
        {
            case SpanSplitEnumeratorMode.SingleElement:
                separatorIndex = input[cursor..].IndexOf(separator);
                separatorLength = 1;
                break;

            case SpanSplitEnumeratorMode.Any:
                separatorIndex = input[cursor..].IndexOfAny(separators);
                separatorLength = 1;
                break;

            case SpanSplitEnumeratorMode.Sequence:
                separatorIndex = input[cursor..].IndexOf(separators);
                separatorLength = separators.Length;
                break;

            case SpanSplitEnumeratorMode.EmptySequence:
                separatorIndex = -1;
                separatorLength = 1;
                break;

            default:
                Debug.Assert(mode == SpanSplitEnumeratorMode.SearchValues, $"Unknown split mode: {mode}");
                separatorIndex = input[cursor..].IndexOfAny(searchValues);
                separatorLength = 1;
                break;
        }

        start = cursor;
        if (separatorIndex >= 0)
        {
            end = start + separatorIndex;
            cursor = end + separatorLength;
        }
        else
        {
            cursor = end = input.Length;
            done = true;
        }

        return true;
    }

    public void Reset()
    {
        start = end = cursor = 0;
        done = false;
    }

    public void SetText(ReadOnlySpan<T> input)
    {
        Reset();
        this.input = input;
    }

    /// <summary>Indicates in which mode <see cref="SpanSplitEnumerator{T}"/> is operating, with regards to how it should interpret its state.</summary>
    private enum SpanSplitEnumeratorMode
    {
        /// <summary>Either a default <see cref="SpanSplitEnumerator{T}"/> was used, or the enumerator has finished enumerating and there's no more work to do.</summary>
        None = 0,

        /// <summary>A single T separator was provided.</summary>
        SingleElement,

        /// <summary>A span of separators was provided, each of which should be treated independently.</summary>
        Any,

        /// <summary>The separator is a span of elements to be treated as a single sequence.</summary>
        Sequence,

        /// <summary>The separator is an empty sequence, such that no splits should be performed.</summary>
        EmptySequence,

        /// <summary>
        /// A <see cref="SearchValues{Char}"/> was provided and should behave the same as with <see cref="Any"/> but with the separators in the <see cref="SearchValues"/>
        /// instance instead of in a <see cref="ReadOnlySpan{Char}"/>.
        /// </summary>
        SearchValues
    }
}
