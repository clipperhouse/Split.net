using System.Buffers;

namespace Split.Extensions;

public static partial class SpanExtensions
{
    public static SplitEnumerator<char> SplitOnAny(this string source, ReadOnlySpan<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this string source, SearchValues<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this ReadOnlySpan<char> source, ReadOnlySpan<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this ReadOnlySpan<char> source, SearchValues<char> separators) => Span.SplitAny(source, separators);
}
