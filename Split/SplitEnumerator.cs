using System.Buffers;

namespace Split;

public ref struct SplitEnumerator<T> where T : IEquatable<T>
{
    private SpanSplitEnumerator<T> _enumerator;

    internal SplitEnumerator(ReadOnlySpan<T> source, T separator)
    {
        _enumerator = MemoryExtensions.Split(source, separator);
    }

    internal SplitEnumerator(ReadOnlySpan<T> source, ReadOnlySpan<T> separator, bool treatAsSingleSeparator)
    {
        _enumerator = MemoryExtensions.Split(source, separator);
    }

    internal SplitEnumerator(ReadOnlySpan<T> source, ReadOnlySpan<T> separator)
    {
        _enumerator = MemoryExtensions.SplitAny(source, separator);
    }

    internal SplitEnumerator(ReadOnlySpan<T> source, SearchValues<T> searchValues)
    {
        _enumerator = MemoryExtensions.SplitAny(source, searchValues);
    }

    public bool MoveNext() => _enumerator.MoveNext();
    public ReadOnlySpan<T> Current => _enumerator._span[_enumerator._startCurrent.._enumerator._endCurrent];
    public SplitEnumerator<T> GetEnumerator() => this;


    /// <summary>
    /// Iterate over all tokens and collects them into a list, allocating a new array for each token.
    /// </summary>
    /// <returns>List<byte[]> or List<char[]>, depending on the input</returns>
    public List<T[]> ToList()
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
    public T[][] ToArray()
    {
        return this.ToList().ToArray();
    }
}
