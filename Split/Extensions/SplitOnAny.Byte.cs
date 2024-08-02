using System.Buffers;

namespace Split.Extensions;

public static partial class SplitExtensions
{
    /// <inheritdoc cref="Split.BytesAny(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>
    public static Enumerator<byte> SplitOnAny(this byte[] source, ReadOnlySpan<byte> separators) => Split.BytesAny(source, separators);

    /// <inheritdoc cref="Split.BytesAny(ReadOnlySpan{byte}, SearchValues{byte})"/>
    public static Enumerator<byte> SplitOnAny(this byte[] source, SearchValues<byte> separators) => Split.BytesAny(source, separators);


    /// <inheritdoc cref="Split.BytesAny(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>
    public static Enumerator<byte> SplitOnAny(this Span<byte> source, ReadOnlySpan<byte> separators) => Split.BytesAny(source, separators);

    /// <inheritdoc cref="Split.BytesAny(ReadOnlySpan{byte}, SearchValues{byte})"/>
    public static Enumerator<byte> SplitOnAny(this Span<byte> source, SearchValues<byte> separators) => Split.BytesAny(source, separators);


    /// <inheritdoc cref="Split.BytesAny(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>
    public static Enumerator<byte> SplitOnAny(this ReadOnlySpan<byte> source, ReadOnlySpan<byte> separators) => Split.BytesAny(source, separators);

    /// <inheritdoc cref="Split.BytesAny(ReadOnlySpan{byte}, SearchValues{byte})"/>
    public static Enumerator<byte> SplitOnAny(this ReadOnlySpan<byte> source, SearchValues<byte> separators) => Split.BytesAny(source, separators);


    /// <inheritdoc cref="Split.BytesAny(Stream, ReadOnlySpan{byte}, int, byte[]?)"/>
    public static StreamEnumerator<byte> SplitOnAny(this Stream stream, ReadOnlySpan<byte> separators, int minBufferBytes = 1024, byte[]? bufferStorage = null)
        => Split.BytesAny(stream, separators, minBufferBytes, bufferStorage);

    /// <inheritdoc cref="Split.BytesAny(Stream, SearchValues{byte}, int, byte[]?)"/>
    public static StreamEnumerator<byte> SplitOnAny(this Stream stream, SearchValues<byte> separators, int minBufferBytes = 1024, byte[]? bufferStorage = null)
        => Split.BytesAny(stream, separators, minBufferBytes, bufferStorage);
}
