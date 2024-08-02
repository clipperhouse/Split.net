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
    /// <param name="reader">The source reader of chars.</param>
    /// <param name="separator">The char on which to split the incoming reader.</param>
    /// <param name="minBufferChars">Optional. The minimum number of chars to maintain in the buffer.</param>
    /// <param name="bufferStorage">
    /// Optional. The backing array for the required buffer. If not passed, a buffer of 2 * minBufferChars will be allocated automatically.
    /// <para>You might pass your own buffer in order to manage your own allocations, such as with <see cref="ArrayPool{T}"/>.</para>
    /// </param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<char> Chars(TextReader reader, char separator, int minBufferChars = 1024, char[]? bufferStorage = null)
    {
        bufferStorage ??= new char[minBufferChars * 2];
        var buffer = new Buffer<char>(reader.Read, minBufferChars, bufferStorage);
        return new StreamEnumerator<char>(buffer, separator);
    }

    /// <summary>
    /// Split an incoming reader of chars into substrings, around a string (multi-char) separator.
    /// </summary>
    /// <param name="reader">The source reader of chars.</param>
    /// <param name="separator">The string on which to split the source reader.</param>
    /// <param name="minBufferChars">Optional. The minimum number of chars to maintain in the buffer.</param>
    /// <param name="bufferStorage">
    /// Optional. The backing array for the required buffer. If not passed, a buffer of 2 * minBufferChars will be allocated automatically.
    /// <para>You might pass your own buffer in order to manage your own allocations, such as with <see cref="ArrayPool{T}"/>.</para>
    /// </param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<char> Chars(TextReader reader, ReadOnlySpan<char> separator, int minBufferChars = 1024, char[]? bufferStorage = null)
    {
        bufferStorage ??= new char[minBufferChars * 2];
        var buffer = new Buffer<char>(reader.Read, minBufferChars, bufferStorage);
        return new StreamEnumerator<char>(buffer, separator, true);
    }

    /// <summary>
    /// Split an incoming reader of chars into substrings, around any char in an array of separators.
    /// </summary>
    /// <param name="reader">The source reader of chars.</param>
    /// <param name="separators">The set of chars on which to split the source string. Any char in the collection will cause a split.</param>
    /// <param name="minBufferChars">Optional. The minimum number of chars to maintain in the buffer.</param>
    /// <param name="bufferStorage">
    /// Optional. The backing array for the required buffer. If not passed, a buffer of 2 * minBufferChars will be allocated automatically.
    /// <para>You might pass your own buffer in order to manage your own allocations, such as with <see cref="ArrayPool{T}"/>.</para>
    /// </param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<char> CharsAny(TextReader reader, ReadOnlySpan<char> separators, int minBufferChars = 1024, char[]? bufferStorage = null)
    {
        bufferStorage ??= new char[minBufferChars * 2];
        var buffer = new Buffer<char>(reader.Read, minBufferChars, bufferStorage);
        return new StreamEnumerator<char>(buffer, separators);
    }

    /// <summary>
    /// Split an incoming reader of chars into substrings, around any char in <see cref="SearchValues{Char}"/>.
    /// </summary>
    /// <param name="reader">The source reader of chars.</param>
    /// <param name="separators"><see cref="SearchValues{Char}"/> is a type optimized for searching any in a set of chars.</param>
    /// <param name="minBufferChars">Optional. The minimum number of chars to maintain in the buffer.</param>
    /// <param name="bufferStorage">
    /// Optional. The backing array for the required buffer. If not passed, a buffer of 2 * minBufferChars will be allocated automatically.
    /// <para>You might pass your own buffer in order to manage your own allocations, such as with <see cref="ArrayPool{T}"/>.</para>
    /// </param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<char> CharsAny(TextReader reader, SearchValues<char> separators, int minBufferChars = 1024, char[]? bufferStorage = null)
    {
        bufferStorage ??= new char[minBufferChars * 2];
        var buffer = new Buffer<char>(reader.Read, minBufferChars, bufferStorage);
        return new StreamEnumerator<char>(buffer, separators);
    }
}
