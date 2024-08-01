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


    /// <inheritdoc cref="Split.Chars(TextReader, char)"/>
    public static StreamEnumerator<char> SplitOn(this TextReader reader, char separator) => Split.Chars(reader, separator);

    /// <inheritdoc cref="Split.Chars(TextReader, ReadOnlySpan{char})"/>
    public static StreamEnumerator<char> SplitOn(this TextReader reader, ReadOnlySpan<char> separator) => Split.Chars(reader, separator);
}
