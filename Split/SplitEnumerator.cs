namespace Split;

public ref struct SplitEnumerator<T> where T : IEquatable<T>
{
    private SpanSplitEnumerator<T> _enumerator;

    public SplitEnumerator(ReadOnlySpan<T> source, ReadOnlySpan<T> separator)
    {
        _enumerator = source.SplitAny(separator);
    }

    public bool MoveNext() => _enumerator.MoveNext();
    public ReadOnlySpan<T> Current => _enumerator._span[_enumerator.Current];
    public SplitEnumerator<T> GetEnumerator() => this;
}
