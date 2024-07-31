using System.Buffers;

namespace Split;

public static partial class Split
{
    public static Enumerator<char> Chars(ReadOnlySpan<char> source, char separator) => new(source, separator);

    public static Enumerator<char> Chars(ReadOnlySpan<char> source, ReadOnlySpan<char> separator) => new(source, separator, true);

    public static Enumerator<char> CharsAny(ReadOnlySpan<char> source, ReadOnlySpan<char> separators) => new(source, separators);

    public static Enumerator<char> CharsAny(ReadOnlySpan<char> source, SearchValues<char> separators) => new(source, separators);

    public static StreamEnumerator<char> Chars(TextReader stream, char separator)
    {
        var buffer = new Buffer<char>(stream.Read, 1024);
        return new StreamEnumerator<char>(buffer, separator);
    }

    public static StreamEnumerator<char> Chars(TextReader stream, ReadOnlySpan<char> separator)
    {
        var buffer = new Buffer<char>(stream.Read, 1024);
        return new StreamEnumerator<char>(buffer, separator, true);

    }
    public static StreamEnumerator<char> CharsAny(TextReader stream, ReadOnlySpan<char> separators)
    {
        var buffer = new Buffer<char>(stream.Read, 1024);
        return new StreamEnumerator<char>(buffer, separators);
    }

    public static StreamEnumerator<char> CharsAny(TextReader stream, SearchValues<char> separators)
    {
        var buffer = new Buffer<char>(stream.Read, 1024);
        return new StreamEnumerator<char>(buffer, separators);
    }

}
