namespace Split.Extensions;

public static partial class SplitExtensions
{
    public static Enumerator<byte> SplitOn(this byte[] source, byte separator) => Split.Bytes(source, separator);

    public static Enumerator<byte> SplitOn(this Span<byte> source, byte separator) => Split.Bytes(source, separator);

    public static Enumerator<byte> SplitOn(this ReadOnlySpan<byte> source, byte separator) => Split.Bytes(source, separator);

    public static Enumerator<byte> SplitOn(this byte[] source, ReadOnlySpan<byte> separator) => Split.Bytes(source, separator);

    public static Enumerator<byte> SplitOn(this Span<byte> source, ReadOnlySpan<byte> separator) => Split.Bytes(source, separator);

    public static Enumerator<byte> SplitOn(this ReadOnlySpan<byte> source, ReadOnlySpan<byte> separator) => Split.Bytes(source, separator);
}
