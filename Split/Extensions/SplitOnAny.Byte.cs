using System.Buffers;

namespace Split.Extensions;

public static partial class SplitExtensions
{
    public static Enumerator<byte> SplitOnAny(this byte[] source, ReadOnlySpan<byte> separators) => Split.BytesAny(source, separators);

    public static Enumerator<byte> SplitOnAny(this byte[] source, SearchValues<byte> separators) => Split.BytesAny(source, separators);

    public static Enumerator<byte> SplitOnAny(this Span<byte> source, SearchValues<byte> separators) => Split.BytesAny(source, separators);

    public static Enumerator<byte> SplitOnAny(this Span<byte> source, ReadOnlySpan<byte> separators) => Split.BytesAny(source, separators);

    public static Enumerator<byte> SplitOnAny(this ReadOnlySpan<byte> source, ReadOnlySpan<byte> separators) => Split.BytesAny(source, separators);

    public static Enumerator<byte> SplitOnAny(this ReadOnlySpan<byte> source, SearchValues<byte> separators) => Split.BytesAny(source, separators);

    public static StreamEnumerator<byte> SplitOnAny(this Stream stream, ReadOnlySpan<byte> separators) => Split.BytesAny(stream, separators);

    public static StreamEnumerator<byte> SplitOnAny(this Stream stream, SearchValues<byte> separators) => Split.BytesAny(stream, separators);
}
