namespace Split.Extensions;

public static partial class SplitExtensions
{
    /// <inheritdoc cref="Split.Chars(ReadOnlySpan{char}, char)"/>
    public static Enumerator<char> SplitOn(this string source, char separator) => Split.Chars(source, separator);

    /// <inheritdoc cref="Split.Chars(ReadOnlySpan{char}, ReadOnlySpan{char})"/>
    public static Enumerator<char> SplitOn(this string source, ReadOnlySpan<char> separator) => Split.Chars(source, separator);


    /// <inheritdoc cref="Split.Chars(ReadOnlySpan{char}, char)"/>
    public static Enumerator<char> SplitOn(this char[] source, char separator) => Split.Chars(source, separator);

    /// <inheritdoc cref="Split.Chars(ReadOnlySpan{char}, ReadOnlySpan{char})"/>
    public static Enumerator<char> SplitOn(this char[] source, ReadOnlySpan<char> separator) => Split.Chars(source, separator);


    /// <inheritdoc cref="Split.Chars(ReadOnlySpan{char}, char)"/>
    public static Enumerator<char> SplitOn(this Span<char> source, char separator) => Split.Chars(source, separator);

    /// <inheritdoc cref="Split.Chars(ReadOnlySpan{char}, ReadOnlySpan{char})"/>
    public static Enumerator<char> SplitOn(this Span<char> source, ReadOnlySpan<char> separator) => Split.Chars(source, separator);


    /// <inheritdoc cref="Split.Chars(ReadOnlySpan{char}, char)"/>
    public static Enumerator<char> SplitOn(this ReadOnlySpan<char> source, char separator) => Split.Chars(source, separator);

    /// <inheritdoc cref="Split.Chars(ReadOnlySpan{char}, ReadOnlySpan{char})"/>
    public static Enumerator<char> SplitOn(this ReadOnlySpan<char> source, ReadOnlySpan<char> separator) => Split.Chars(source, separator);


    /// <inheritdoc cref="Split.Chars(TextReader, char, int, char[]?)"/>
    public static StreamEnumerator<char> SplitOn(this TextReader reader, char separator, int minBufferChars = 1024, char[]? bufferStorage = null)
        => Split.Chars(reader, separator, minBufferChars, bufferStorage);

    /// <inheritdoc cref="Split.Chars(TextReader, ReadOnlySpan{char}, int, char[]?)"/>
    public static StreamEnumerator<char> SplitOn(this TextReader reader, ReadOnlySpan<char> separator, int minBufferChars = 1024, char[]? bufferStorage = null)
        => Split.Chars(reader, separator, minBufferChars, bufferStorage);
}
