namespace Split.Extensions;

public static partial class SpanExtensions
{
    public static SplitEnumerator<char> SplitOn(this string source, char separator) => Span.Split(source, separator);

    public static SplitEnumerator<char> SplitOn(this string source, ReadOnlySpan<char> separator) => Span.Split(source, separator);

    public static SplitEnumerator<char> SplitOn(this ReadOnlySpan<char> source, char separator) => Span.Split(source, separator);

    public static SplitEnumerator<char> SplitOn(this ReadOnlySpan<char> source, ReadOnlySpan<char> separator) => Span.Split(source, separator);

}
