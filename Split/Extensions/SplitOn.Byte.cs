namespace Split.Extensions;

public static partial class SpanExtensions
{
    public static SplitEnumerator<byte> SplitOn(this byte[] source, byte separator) => Span.Split(source, separator);

    public static SplitEnumerator<byte> SplitOn(this Span<byte> source, byte separator) => Span.Split(source, separator);

    public static SplitEnumerator<byte> SplitOn(this ReadOnlySpan<byte> source, byte separator) => Span.Split(source, separator);

    public static SplitEnumerator<byte> SplitOn(this byte[] source, ReadOnlySpan<byte> separator) => Span.Split(source, separator);

    public static SplitEnumerator<byte> SplitOn(this Span<byte> source, ReadOnlySpan<byte> separator) => Span.Split(source, separator);

    public static SplitEnumerator<byte> SplitOn(this ReadOnlySpan<byte> source, ReadOnlySpan<byte> separator) => Span.Split(source, separator);
}
