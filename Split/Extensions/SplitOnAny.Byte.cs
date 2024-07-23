using System.Buffers;

namespace Split.Extensions;

public static partial class SpanExtensions
{
    public static SplitEnumerator<byte> SplitOnAny(this byte[] source, ReadOnlySpan<byte> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<byte> SplitOnAny(this byte[] source, SearchValues<byte> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<byte> SplitOnAny(this Span<byte> source, SearchValues<byte> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<byte> SplitOnAny(this Span<byte> source, ReadOnlySpan<byte> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<byte> SplitOnAny(this ReadOnlySpan<byte> source, ReadOnlySpan<byte> separators) => Span.SplitAny(source, separators);

    public static SplitEnumerator<byte> SplitOnAny(this ReadOnlySpan<byte> source, SearchValues<byte> separators) => Span.SplitAny(source, separators);
}
