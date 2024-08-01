namespace Split.Extensions;

public static partial class SplitExtensions
{
    /// <inheritdoc cref="Split.Bytes(ReadOnlySpan{byte}, byte)"/>
    public static Enumerator<byte> SplitOn(this byte[] source, byte separator) => Split.Bytes(source, separator);

    /// <inheritdoc cref="Split.Bytes(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>
    public static Enumerator<byte> SplitOn(this byte[] source, ReadOnlySpan<byte> separator) => Split.Bytes(source, separator);


    /// <inheritdoc cref="Split.Bytes(ReadOnlySpan{byte}, byte)"/>
    public static Enumerator<byte> SplitOn(this Span<byte> source, byte separator) => Split.Bytes(source, separator);

    /// <inheritdoc cref="Split.Bytes(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>
    public static Enumerator<byte> SplitOn(this Span<byte> source, ReadOnlySpan<byte> separator) => Split.Bytes(source, separator);


    /// <inheritdoc cref="Split.Bytes(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>
    public static Enumerator<byte> SplitOn(this ReadOnlySpan<byte> source, ReadOnlySpan<byte> separator) => Split.Bytes(source, separator);

    /// <inheritdoc cref="Split.Bytes(ReadOnlySpan{byte}, byte)"/>
    public static Enumerator<byte> SplitOn(this ReadOnlySpan<byte> source, byte separator) => Split.Bytes(source, separator);


    /// <inheritdoc cref="Split.Bytes(Stream, byte)"/>
    public static StreamEnumerator<byte> SplitOn(this Stream stream, byte separator) => Split.Bytes(stream, separator);

    /// <inheritdoc cref="Split.Bytes(Stream, ReadOnlySpan{byte})"/>
    public static StreamEnumerator<byte> SplitOn(this Stream stream, ReadOnlySpan<byte> separator) => Split.Bytes(stream, separator);
}
