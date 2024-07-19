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
    public ReadOnlySpan<T> Current => _enumerator._span[_enumerator.Current];
    public SplitEnumerator<T> GetEnumerator() => this;
}
