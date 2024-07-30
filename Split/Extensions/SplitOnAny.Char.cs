using System.Buffers;
using Microsoft.Extensions.Primitives;

namespace Split.Extensions;

public static partial class SplitExtensions
{
    public static Enumerator<char> SplitOnAny(this string source, ReadOnlySpan<char> separators) => Split.CharsAny(source, separators);

    public static Enumerator<char> SplitOnAny(this string source, SearchValues<char> separators) => Split.CharsAny(source, separators);

    public static Enumerator<char> SplitOnAny(this char[] source, ReadOnlySpan<char> separators) => Split.CharsAny(source, separators);

    public static Enumerator<char> SplitOnAny(this char[] source, SearchValues<char> separators) => Split.CharsAny(source, separators);

    public static Enumerator<char> SplitOnAny(this Span<char> source, ReadOnlySpan<char> separators) => Split.CharsAny(source, separators);

    public static Enumerator<char> SplitOnAny(this Span<char> source, SearchValues<char> separators) => Split.CharsAny(source, separators);

    public static Enumerator<char> SplitOnAny(this ReadOnlySpan<char> source, ReadOnlySpan<char> separators) => Split.CharsAny(source, separators);

    public static Enumerator<char> SplitOnAny(this ReadOnlySpan<char> source, SearchValues<char> separators) => Split.CharsAny(source, separators);
}
