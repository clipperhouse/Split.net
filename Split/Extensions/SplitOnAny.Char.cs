using System.Buffers;
using Microsoft.Extensions.Primitives;

namespace Split.Extensions;

public static partial class SplitExtensions
{
    /// <inheritdoc cref="Split.CharsAny(ReadOnlySpan{char}, ReadOnlySpan{char})"/>
    public static Enumerator<char> SplitOnAny(this string source, ReadOnlySpan<char> separators) => Split.CharsAny(source, separators);

    /// <inheritdoc cref="Split.CharsAny(ReadOnlySpan{char}, SearchValues{char})"/>
    public static Enumerator<char> SplitOnAny(this string source, SearchValues<char> separators) => Split.CharsAny(source, separators);


    /// <inheritdoc cref="Split.CharsAny(ReadOnlySpan{char}, ReadOnlySpan{char})"/>
    public static Enumerator<char> SplitOnAny(this char[] source, ReadOnlySpan<char> separators) => Split.CharsAny(source, separators);

    /// <inheritdoc cref="Split.CharsAny(ReadOnlySpan{char}, SearchValues{char})"/>
    public static Enumerator<char> SplitOnAny(this char[] source, SearchValues<char> separators) => Split.CharsAny(source, separators);


    /// <inheritdoc cref="Split.CharsAny(ReadOnlySpan{char}, ReadOnlySpan{char})"/>
    public static Enumerator<char> SplitOnAny(this Span<char> source, ReadOnlySpan<char> separators) => Split.CharsAny(source, separators);

    /// <inheritdoc cref="Split.CharsAny(ReadOnlySpan{char}, SearchValues{char})"/>
    public static Enumerator<char> SplitOnAny(this Span<char> source, SearchValues<char> separators) => Split.CharsAny(source, separators);


    /// <inheritdoc cref="Split.CharsAny(ReadOnlySpan{char}, ReadOnlySpan{char})"/>
    public static Enumerator<char> SplitOnAny(this ReadOnlySpan<char> source, ReadOnlySpan<char> separators) => Split.CharsAny(source, separators);

    /// <inheritdoc cref="Split.CharsAny(ReadOnlySpan{char}, SearchValues{char})"/>
    public static Enumerator<char> SplitOnAny(this ReadOnlySpan<char> source, SearchValues<char> separators) => Split.CharsAny(source, separators);


    /// <inheritdoc cref="Split.CharsAny(TextReader, SearchValues{char}, int, char[]?)"/>
    public static StreamEnumerator<char> SplitOnAny(this TextReader reader, ReadOnlySpan<char> separators, int minBufferChars = 1024, char[]? bufferStorage = null)
        => Split.CharsAny(reader, separators, minBufferChars, bufferStorage);

    /// <inheritdoc cref="Split.CharsAny(TextReader, SearchValues{char}, int, char[]?)"/>
    public static StreamEnumerator<char> SplitOnAny(this TextReader reader, SearchValues<char> separators, int minBufferChars = 1024, char[]? bufferStorage = null)
        => Split.CharsAny(reader, separators, minBufferChars, bufferStorage);
}
