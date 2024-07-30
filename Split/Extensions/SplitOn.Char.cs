namespace Split.Extensions;

public static partial class SplitExtensions
{
    public static Enumerator<char> SplitOn(this string source, char separator) => Split.Chars(source, separator);

    public static Enumerator<char> SplitOn(this string source, ReadOnlySpan<char> separator) => Split.Chars(source, separator);

    public static Enumerator<char> SplitOn(this char[] source, char separator) => Split.Chars(source, separator);

    public static Enumerator<char> SplitOn(this char[] source, ReadOnlySpan<char> separator) => Split.Chars(source, separator);

    public static Enumerator<char> SplitOn(this Span<char> source, char separator) => Split.Chars(source, separator);

    public static Enumerator<char> SplitOn(this Span<char> source, ReadOnlySpan<char> separator) => Split.Chars(source, separator);

    public static Enumerator<char> SplitOn(this ReadOnlySpan<char> source, char separator) => Split.Chars(source, separator);

    public static Enumerator<char> SplitOn(this ReadOnlySpan<char> source, ReadOnlySpan<char> separator) => Split.Chars(source, separator);

}
