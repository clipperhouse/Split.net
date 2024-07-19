using System.Buffers;

namespace Split;

public static class Span
{
    public static SplitEnumerator<char> Split(ReadOnlySpan<char> source, char separator) =>
        new SplitEnumerator<char>(source, separator);

    public static SplitEnumerator<char> Split(ReadOnlySpan<char> source, ReadOnlySpan<char> separator) =>
        new SplitEnumerator<char>(source, separator, true);

    public static SplitEnumerator<char> SplitAny(ReadOnlySpan<char> source, ReadOnlySpan<char> separators) =>
        new SplitEnumerator<char>(source, separators);

    public static SplitEnumerator<char> SplitAny(ReadOnlySpan<char> source, SearchValues<char> separators) =>
        new SplitEnumerator<char>(source, separators);

    public static SplitEnumerator<byte> Split(ReadOnlySpan<byte> source, byte separator) =>
        new SplitEnumerator<byte>(source, separator);

    public static SplitEnumerator<byte> Split(ReadOnlySpan<byte> source, ReadOnlySpan<byte> separator) =>
        new SplitEnumerator<byte>(source, separator, true);

    public static SplitEnumerator<byte> SplitAny(ReadOnlySpan<byte> source, ReadOnlySpan<byte> separators) =>
        new SplitEnumerator<byte>(source, separators);

    public static SplitEnumerator<byte> SplitAny(ReadOnlySpan<byte> source, SearchValues<byte> separators) =>
        new SplitEnumerator<byte>(source, separators);

}
