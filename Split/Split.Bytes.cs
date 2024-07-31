using System.Buffers;

namespace Split;

public static partial class Split
{
    public static Enumerator<byte> Bytes(ReadOnlySpan<byte> source, byte separator) => new(source, separator);

    public static Enumerator<byte> Bytes(ReadOnlySpan<byte> source, ReadOnlySpan<byte> separator) => new(source, separator, true);

    public static Enumerator<byte> BytesAny(ReadOnlySpan<byte> source, ReadOnlySpan<byte> separators) => new(source, separators);

    public static Enumerator<byte> BytesAny(ReadOnlySpan<byte> source, SearchValues<byte> separators) => new(source, separators);

    public static StreamEnumerator<byte> Bytes(Stream stream, byte separator)
    {
        var buffer = new Buffer<byte>(stream.Read, 1024);
        return new StreamEnumerator<byte>(buffer, separator);
    }

    public static StreamEnumerator<byte> Bytes(Stream stream, ReadOnlySpan<byte> separator)
    {
        var buffer = new Buffer<byte>(stream.Read, 1024);
        return new StreamEnumerator<byte>(buffer, separator, true);

    }

    public static StreamEnumerator<byte> BytesAny(Stream stream, ReadOnlySpan<byte> separators)
    {
        var buffer = new Buffer<byte>(stream.Read, 1024);
        return new StreamEnumerator<byte>(buffer, separators);
    }

    public static StreamEnumerator<byte> BytesAny(Stream stream, SearchValues<byte> separators)
    {
        var buffer = new Buffer<byte>(stream.Read, 1024);
        return new StreamEnumerator<byte>(buffer, separators);
    }
}
