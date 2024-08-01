using System.Buffers;

namespace Split;

public static partial class Split
{
    /// <summary>
    /// Split a source string into substrings, around a single-char separator.
    /// </summary>
    /// <param name="source">The string to split.</param>
    /// <param name="separator">The character on which to split the string.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static Enumerator<char> Chars(ReadOnlySpan<char> source, char separator) => new(source, separator);

    /// <summary>
    /// Split a source string into substrings, around a string separator.
    /// </summary>
    /// <param name="source">The string to split.</param>
    /// <param name="separator">The string on which to split the source string.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static Enumerator<char> Chars(ReadOnlySpan<char> source, ReadOnlySpan<char> separator) => new(source, separator, true);

    /// <summary>
    /// Split a source string into substrings, around any char in an array of separators.
    /// </summary>
    /// <param name="source">The string to split.</param>
    /// <param name="separators">The set of chars on which to split the source string. Any char in the collection will cause a split.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static Enumerator<char> CharsAny(ReadOnlySpan<char> source, ReadOnlySpan<char> separators) => new(source, separators);

    /// <summary>
    /// Split a source string into substrings, around any char in SearchValues.
    /// </summary>
    /// <param name="source">The string to split.</param>
    /// <param name="separators">SearchValues is a type optimized for searching any in a set of char.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static Enumerator<char> CharsAny(ReadOnlySpan<char> source, SearchValues<char> separators) => new(source, separators);

    /// <summary>
    /// Splits an incoming reader of chars into substrings, around a single-char separator.
    /// </summary>
    /// <param name="stream">The source reader of chars.</param>
    /// <param name="separator">The char on which to split the incoming reader.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<char> Chars(TextReader stream, char separator)
    {
        var buffer = new Buffer<char>(stream.Read, 1024);
        return new StreamEnumerator<char>(buffer, separator);
    }

    /// <summary>
    /// Split an incoming reader of chars into substrings, around a string (multi-char) separator.
    /// </summary>
    /// <param name="stream">The source reader of chars.</param>
    /// <param name="separator">The string on which to split the source reader.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<char> Chars(TextReader stream, ReadOnlySpan<char> separator)
    {
        var buffer = new Buffer<char>(stream.Read, 1024);
        return new StreamEnumerator<char>(buffer, separator, true);
    }

    /// <summary>
    /// Split an incoming reader of chars into substrings, around any char in an array of separators.
    /// </summary>
    /// <param name="stream">The source reader of chars.</param>
    /// <param name="separators">The set of chars on which to split the source string. Any char in the collection will cause a split.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<char> CharsAny(TextReader stream, ReadOnlySpan<char> separators)
    {
        var buffer = new Buffer<char>(stream.Read, 1024);
        return new StreamEnumerator<char>(buffer, separators);
    }

    /// <summary>
    /// Split an incoming reader of chars into substrings, around any char in <see cref="SearchValues{Char}"/>.
    /// </summary>
    /// <param name="stream">The source reader of chars.</param>
    /// <param name="separators"><see cref="SearchValues{Char}"/> is a type optimized for searching any in a set of chars.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<char> CharsAny(TextReader stream, SearchValues<char> separators)
    {
        var buffer = new Buffer<char>(stream.Read, 1024);
        return new StreamEnumerator<char>(buffer, separators);
    }
}
