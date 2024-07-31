using System.Buffers;
using System.Runtime.CompilerServices;

namespace Split;

public ref struct Enumerator<T> where T : IEquatable<T>
{
    private SpanSplitEnumerator<T> en;

    internal Enumerator(ReadOnlySpan<T> source, T separator)
    {
        en = MemoryExtensions.Split(source, separator);
    }

    internal Enumerator(ReadOnlySpan<T> source, ReadOnlySpan<T> separator, bool treatAsSingleSeparator)
    {
        en = MemoryExtensions.Split(source, separator);
    }

    internal Enumerator(ReadOnlySpan<T> source, ReadOnlySpan<T> separators)
    {
        en = MemoryExtensions.SplitAny(source, separators);
    }

    internal Enumerator(ReadOnlySpan<T> source, SearchValues<T> searchValues)
    {
        en = MemoryExtensions.SplitAny(source, searchValues);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext() => en.MoveNext();

    public readonly ReadOnlySpan<T> Current => en.input[en.start..en.end];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Enumerator<T> GetEnumerator() => this;


    /// <summary>
    /// Iterate over all tokens and collects them into a list, allocating a new array for each token.
    /// </summary>
    /// <returns>List<byte[]> or List<char[]>, depending on the input</returns>
    public readonly List<T[]> ToList()
    {
        var result = new List<T[]>();
        foreach (var token in this)
        {
            result.Add(token.ToArray());
        }
        return result;
    }

    /// <summary>
    /// Iterates over all tokens and collects them into an array, allocating a new array for each token.
    /// </summary>
    /// <returns>byte[][] or char[][], depending on the input</returns>
    public readonly T[][] ToArray()
    {
        return this.ToList().ToArray();
    }
}
