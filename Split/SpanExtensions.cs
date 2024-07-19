using System.Buffers;

namespace Split;

public static class SpanExtensions
{
    public static SplitEnumerator<T> SplitOn<T>(this ReadOnlySpan<T> source, T separator) where T : IEquatable<T> =>
        new SplitEnumerator<T>(source, separator);

    public static SplitEnumerator<T> SplitOn<T>(this ReadOnlySpan<T> source, ReadOnlySpan<T> separator) where T : IEquatable<T> =>
        new SplitEnumerator<T>(source, separator, true);

    public static SplitEnumerator<T> SplitOnAny<T>(this ReadOnlySpan<T> source, ReadOnlySpan<T> separators) where T : IEquatable<T> =>
        new SplitEnumerator<T>(source, separators);

    public static SplitEnumerator<T> SplitOnAny<T>(this ReadOnlySpan<T> source, SearchValues<T> separators) where T : IEquatable<T> =>
        new SplitEnumerator<T>(source, separators);
}
