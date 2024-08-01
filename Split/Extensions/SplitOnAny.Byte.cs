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


    /// <inheritdoc cref="Split.BytesAny(Stream, ReadOnlySpan{byte})"/>
    public static StreamEnumerator<byte> SplitOnAny(this Stream stream, ReadOnlySpan<byte> separators) => Split.BytesAny(stream, separators);

    /// <inheritdoc cref="Split.BytesAny(Stream, SearchValues{byte})"/>
    public static StreamEnumerator<byte> SplitOnAny(this Stream stream, SearchValues<byte> separators) => Split.BytesAny(stream, separators);
}
