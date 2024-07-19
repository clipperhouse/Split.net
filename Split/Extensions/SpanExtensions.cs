using System.Buffers;

namespace Split.Extensions;

public static class SpanExtensions
{
    public static SplitEnumerator<char> SplitOn(this string source, char separator) =>
        Span.Split(source, separator);

    public static SplitEnumerator<char> SplitOn(this string source, string separator) =>
        Span.Split(source, separator);

    public static SplitEnumerator<char> SplitOn(this ReadOnlySpan<char> source, char separator) =>
        Span.Split(source, separator);

    public static SplitEnumerator<char> SplitOn(this ReadOnlySpan<char> source, ReadOnlySpan<char> separator) =>
        Span.Split(source, separator);

    public static SplitEnumerator<char> SplitOnAny(this string source, ReadOnlySpan<char> separators) =>
        Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this ReadOnlySpan<char> source, ReadOnlySpan<char> separators) =>
        Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this ReadOnlySpan<char> source, string separators) =>
        Span.SplitAny(source, separators);

    public static SplitEnumerator<char> SplitOnAny(this string source, SearchValues<char> separators) =>
        Span.SplitAny(source, separators);
    public static SplitEnumerator<char> SplitOnAny(this ReadOnlySpan<char> source, SearchValues<char> separators) =>
        Span.SplitAny(source, separators);


    public static SplitEnumerator<byte> SplitOn(this byte[] source, byte separator) =>
        Span.Split(source, separator);

    public static SplitEnumerator<byte> SplitOn(this byte[] source, ReadOnlySpan<byte> separator) =>
        Span.Split(source, separator);

    public static SplitEnumerator<byte> SplitOn(this ReadOnlySpan<byte> source, byte separator) =>
        Span.Split(source, separator);

    public static SplitEnumerator<byte> SplitOn(this ReadOnlySpan<byte> source, ReadOnlySpan<byte> separator) =>
        Span.Split(source, separator);


    public static SplitEnumerator<byte> SplitOnAny(this byte[] source, ReadOnlySpan<byte> separators) =>
        Span.SplitAny(source, separators);

    public static SplitEnumerator<byte> SplitOnAny(this byte[] source, SearchValues<byte> separators) =>
        Span.SplitAny(source, separators);

    public static SplitEnumerator<byte> SplitOnAny(this ReadOnlySpan<byte> source, ReadOnlySpan<byte> separators) =>
        Span.SplitAny(source, separators);

    public static SplitEnumerator<byte> SplitOnAny(this ReadOnlySpan<byte> source, SearchValues<byte> separators) =>
        Span.SplitAny(source, separators);

}
