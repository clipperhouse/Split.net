// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/runtime/blob/main/LICENSE.TXT

// This is the Microsoft implementation from .Net 9.0, intended as a backport for .Net 8.0

using System.Buffers;

namespace Split;

public static partial class MemoryExtensions
{
    /// <summary>
    /// Returns a type that allows for enumeration of each element within a split span
    /// using the provided separator character.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="source">The source span to be enumerated.</param>
    /// <param name="separator">The separator character to be used to split the provided span.</param>
    /// <returns>Returns a <see cref="SpanSplitEnumerator{T}"/>.</returns>
    public static SpanSplitEnumerator<T> Split<T>(this ReadOnlySpan<T> source, T separator) where T : IEquatable<T> =>
        new SpanSplitEnumerator<T>(source, separator);

    /// <summary>
    /// Returns a type that allows for enumeration of each element within a split span
    /// using the provided separator span.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="source">The source span to be enumerated.</param>
    /// <param name="separator">The separator span to be used to split the provided span.</param>
    /// <returns>Returns a <see cref="SpanSplitEnumerator{T}"/>.</returns>
    public static SpanSplitEnumerator<T> Split<T>(this ReadOnlySpan<T> source, ReadOnlySpan<T> separator) where T : IEquatable<T> =>
        new SpanSplitEnumerator<T>(source, separator, treatAsSingleSeparator: true);

    /// <summary>
    /// Returns a type that allows for enumeration of each element within a split span
    /// using any of the provided elements.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="source">The source span to be enumerated.</param>
    /// <param name="separators">The separators to be used to split the provided span.</param>
    /// <returns>Returns a <see cref="SpanSplitEnumerator{T}"/>.</returns>
    /// <remarks>
    /// If <typeparamref name="T"/> is <see cref="char"/> and if <paramref name="separators"/> is empty,
    /// all Unicode whitespace characters are used as the separators. This matches the behavior of when
    /// <see cref="string.Split(char[])"/> and related overloads are used with an empty separator array,
    /// or when <see cref="SplitAny(ReadOnlySpan{char}, Span{Range}, ReadOnlySpan{char}, StringSplitOptions)"/>
    /// is used with an empty separator span.
    /// </remarks>
    public static SpanSplitEnumerator<T> SplitAny<T>(this ReadOnlySpan<T> source, ReadOnlySpan<T> separators) where T : IEquatable<T> =>
        new SpanSplitEnumerator<T>(source, separators);

    /// <summary>
    /// Returns a type that allows for enumeration of each element within a split span
    /// using the provided <see cref="SpanSplitEnumerator{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="source">The source span to be enumerated.</param>
    /// <param name="separators">The <see cref="SpanSplitEnumerator{T}"/> to be used to split the provided span.</param>
    /// <returns>Returns a <see cref="SpanSplitEnumerator{T}"/>.</returns>
    /// <remarks>
    /// Unlike <see cref="SplitAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})"/>, the <paramref name="separators"/> is not checked for being empty.
    /// An empty <paramref name="separators"/> will result in no separators being found, regardless of the type of <typeparamref name="T"/>,
    /// whereas <see cref="SplitAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})"/> will use all Unicode whitespace characters as separators if <paramref name="separators"/> is
    /// empty and <typeparamref name="T"/> is <see cref="char"/>.
    /// </remarks>
    public static SpanSplitEnumerator<T> SplitAny<T>(this ReadOnlySpan<T> source, SearchValues<T> separators) where T : IEquatable<T> =>
        new SpanSplitEnumerator<T>(source, separators);
}