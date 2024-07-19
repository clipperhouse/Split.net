namespace Tests;

using System.Buffers;
using System.Text;
using Split;
using Split.Extensions;

public class BasicTests
{
    [Fact]
    public void Readme()
    {
        var example = "Hello, 🌏 world. 你好, 世界. ";

        // The tokenizer can split words, graphemes or sentences.
        // It operates on strings, UTF-8 bytes, and streams.

        Console.WriteLine("StdLib:");

        var words = example.AsSpan().SplitAny(". ");

        // Iterate over the tokens
        foreach (var range in words)
        {
            Console.WriteLine(example[range].ToString());
        }

        /*
        Hello
        ,

        🌏

        world
        .

        你
        好
        ，
        世
        界
        .
        */

        Console.WriteLine("bytes:");

        var bytes = Encoding.UTF8.GetBytes(example);
        var ws = new SpanSplitEnumerator<byte>(bytes, []);

        foreach (var range in ws)
        {
            Console.WriteLine(Encoding.UTF8.GetString(bytes[range]));

        }

        Console.WriteLine("Mine:");

        var words2 = bytes.SplitOnAny(". "u8); ;

        foreach (var word in words2)
        {
            Console.WriteLine("\"" + Encoding.UTF8.GetString(word) + "\"");
        }
    }

    [Fact]
    public void Overloads()
    {
        // Just to avoid breaking the API, no actual tests

        var example = "foo";
        {
            char separator = ' ';
            Span.Split(example, separator);

            var separators = ". ";
            Span.Split(example, separators);
            Span.SplitAny(example, separators);

            var search = SearchValues.Create(separators);
            Span.SplitAny(example, search);
        }

        var bytes = Encoding.UTF8.GetBytes(example);
        {
            byte separator = (byte)' ';
            Span.Split(bytes, separator);

            var separators = ". "u8;
            Span.Split(bytes, separators);
            Span.SplitAny(bytes, separators);

            var search = SearchValues.Create(separators);
            Span.SplitAny(bytes, search);
        }
    }

    [Fact]
    public void Extensions()
    {
        // Just to avoid breaking the API, no actual tests

        var example = "foo";
        {
            char separator = ' ';
            example.SplitOn(separator);
            example.AsSpan().SplitOn(separator);

            var separators = ". ";
            example.SplitOn(separators);
            example.SplitOn(separators.AsSpan());
            example.AsSpan().SplitOn(separators);
            example.AsSpan().SplitOn(separators.AsSpan());

            example.SplitOnAny(separators);
            example.SplitOnAny(separators.AsSpan());
            example.AsSpan().SplitOnAny(separators);
            example.AsSpan().SplitOnAny(separators.AsSpan());

            var search = SearchValues.Create(separators);
            example.SplitOnAny(search);
            example.AsSpan().SplitOnAny(search);
        }

        var bytes = Encoding.UTF8.GetBytes(example);
        {
            byte separator = (byte)' ';
            bytes.SplitOn(separator);
            bytes.AsSpan().SplitOn(separator);
            ReadOnlySpan<byte> rbytes = bytes.AsSpan();
            rbytes.SplitOn(separator);

            var separators = ". "u8;
            bytes.AsSpan().SplitOn(separators);
            bytes.SplitOnAny(separators);

            var search = SearchValues.Create(separators);
            bytes.SplitOnAny(search);
        }
    }
}
