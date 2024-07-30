using System.Buffers;

namespace Split;

public static class Split
{
    public static Enumerator<char> Chars(ReadOnlySpan<char> source, char separator) => new(source, separator);

    public static Enumerator<char> Chars(ReadOnlySpan<char> source, ReadOnlySpan<char> separator) => new(source, separator, true);

    public static Enumerator<char> CharsAny(ReadOnlySpan<char> source, ReadOnlySpan<char> separators) => new(source, separators);

    public static Enumerator<char> CharsAny(ReadOnlySpan<char> source, SearchValues<char> separators) => new(source, separators);

    public static Enumerator<byte> Bytes(ReadOnlySpan<byte> source, byte separator) => new(source, separator);

    public static Enumerator<byte> Bytes(ReadOnlySpan<byte> source, ReadOnlySpan<byte> separator) => new(source, separator, true);

    public static Enumerator<byte> BytesAny(ReadOnlySpan<byte> source, ReadOnlySpan<byte> separators) => new(source, separators);

    public static Enumerator<byte> BytesAny(ReadOnlySpan<byte> source, SearchValues<byte> separators) => new(source, separators);

}
