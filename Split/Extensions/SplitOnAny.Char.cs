using System.Buffers;
using Microsoft.Extensions.Primitives;

namespace Split.Extensions;

public static partial class SpanExtensions
{
    public static SplitEnumerator<char> SplitOnAny(this string source, ReadOnlySpan<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this string source, SearchValues<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this char[] source, ReadOnlySpan<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this char[] source, SearchValues<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this Span<char> source, ReadOnlySpan<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this Span<char> source, SearchValues<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this ReadOnlySpan<char> source, ReadOnlySpan<char> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this ReadOnlySpan<char> source, SearchValues<char> separators) => Span.SplitAny(source, separators);
}
