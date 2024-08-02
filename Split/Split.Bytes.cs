using System.Buffers;

namespace Split;

public static partial class Split
{
    /// <summary>
    /// Split source bytes into subslices, around a single byte separator.
    /// </summary>
    /// <param name="source">The string to split</param>
    /// <param name="separator">The byte on which to split the string</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static Enumerator<byte> Bytes(ReadOnlySpan<byte> source, byte separator) => new(source, separator);

    /// <summary>
    /// Split source bytes into subslices, around a multi-byte separator.
    /// </summary>
    /// <param name="source">The string to split</param>
    /// <param name="separator">The byte string on which to split the source string.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static Enumerator<byte> Bytes(ReadOnlySpan<byte> source, ReadOnlySpan<byte> separator) => new(source, separator, true);

    /// <summary>
    /// Split source bytes into subslices, around any byte in an array of separators.
    /// </summary>
    /// <param name="source">The string to split</param>
    /// <param name="separators">The set of bytes on which to split the source string. Any byte in the collection will cause a split.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static Enumerator<byte> BytesAny(ReadOnlySpan<byte> source, ReadOnlySpan<byte> separators) => new(source, separators);

    /// <summary>
    /// Split source bytes into subslices, around any byte in an array of separators.
    /// </summary>
    /// <param name="source">The string to split</param>
    /// <param name="separators">SearchValues is a type optimized for searching any in a set of bytes.</param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static Enumerator<byte> BytesAny(ReadOnlySpan<byte> source, SearchValues<byte> separators) => new(source, separators);

    /// <summary>
    /// Splits an incoming stream into subslices, around a single byte separator.
    /// </summary>
    /// <param name="stream">The source stream of bytes.</param>
    /// <param name="separator">The byte on which to split the string.</param>
    /// <param name="minBufferBytes">Optional. The minimum number of bytes to maintain in the buffer.</param>
    /// <param name="bufferStorage">
    /// Optional. The backing array for the required buffer. If not passed, a buffer of 2 * minBufferChars will be allocated automatically.
    /// <para>You might pass your own buffer in order to manage your own allocations, such as with <see cref="ArrayPool{T}"/>.</para>
    /// </param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<byte> Bytes(Stream stream, byte separator, int minBufferBytes = 1024, byte[]? bufferStorage = null)
    {
        bufferStorage ??= new byte[minBufferBytes * 2];
        var buffer = new Buffer<byte>(stream.Read, minBufferBytes, bufferStorage);
        return new StreamEnumerator<byte>(buffer, separator);
    }

    /// <summary>
    /// Split an incoming stream into subslices, around a multi-byte separator.
    /// </summary>
    /// <param name="stream">The source stream of bytes.</param>
    /// <param name="separator">The byte string on which to split the source string.</param>
    /// <param name="minBufferBytes">Optional. The minimum number of bytes to maintain in the buffer.</param>
    /// <param name="bufferStorage">
    /// Optional. The backing array for the required buffer. If not passed, a buffer of 2 * minBufferChars will be allocated automatically.
    /// <para>You might pass your own buffer in order to manage your own allocations, such as with <see cref="ArrayPool{T}"/>.</para>
    /// </param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<byte> Bytes(Stream stream, ReadOnlySpan<byte> separator, int minBufferBytes = 1024, byte[]? bufferStorage = null)
    {
        bufferStorage ??= new byte[minBufferBytes * 2];
        var buffer = new Buffer<byte>(stream.Read, minBufferBytes, bufferStorage);
        return new StreamEnumerator<byte>(buffer, separator, true);

    }

    /// <summary>
    /// Split an incoming stream into subslices, around any byte in an array of separators.
    /// </summary>
    /// <param name="stream">The source stream of bytes.</param>
    /// <param name="separators">The set of bytes on which to split the source string. Any byte in the collection will cause a split.</param>
    /// <param name="minBufferBytes">Optional. The minimum number of bytes to maintain in the buffer.</param>
    /// <param name="bufferStorage">
    /// Optional. The backing array for the required buffer. If not passed, a buffer of 2 * minBufferChars will be allocated automatically.
    /// <para>You might pass your own buffer in order to manage your own allocations, such as with <see cref="ArrayPool{T}"/>.</para>
    /// </param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<byte> BytesAny(Stream stream, ReadOnlySpan<byte> separators, int minBufferBytes = 1024, byte[]? bufferStorage = null)
    {
        bufferStorage ??= new byte[minBufferBytes * 2];
        var buffer = new Buffer<byte>(stream.Read, minBufferBytes, bufferStorage);
        return new StreamEnumerator<byte>(buffer, separators);
    }

    /// <summary>
    /// Split an incoming stream into subslices, around any byte in <see cref="SearchValues{Byte}"/>.
    /// </summary>
    /// <param name="stream">The source stream of bytes.</param>
    /// <param name="separators"><see cref="SearchValues{Byte}"/> is a type optimized for searching any in a set of bytes.</param>
    /// <param name="minBufferBytes">Optional. The minimum number of bytes to maintain in the buffer.</param>
    /// <param name="bufferStorage">
    /// Optional. The backing array for the required buffer. If not passed, a buffer of 2 * minBufferChars will be allocated automatically.
    /// <para>You might pass your own buffer in order to manage your own allocations, such as with <see cref="ArrayPool{T}"/>.</para>
    /// </param>
    /// <returns>An enumerator of subslices. Use foreach.</returns>
    public static StreamEnumerator<byte> BytesAny(Stream stream, SearchValues<byte> separators, int minBufferBytes = 1024, byte[]? bufferStorage = null)
    {
        bufferStorage ??= new byte[minBufferBytes * 2];
        var buffer = new Buffer<byte>(stream.Read, minBufferBytes, bufferStorage);
        return new StreamEnumerator<byte>(buffer, separators);
    }
}
