namespace Tests;

using System.Reflection.PortableExecutable;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using Split;

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
            Console.WriteLine(example[range].ToString().AddDoubleQuote());
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
            Console.WriteLine(Encoding.UTF8.GetString(bytes[range]).AddDoubleQuote());

        }

        Console.WriteLine("Mine:");

        var words2 = new SplitEnumerator<char>(example, " .");

        foreach (var word in words2)
        {
            Console.WriteLine(word.ToString().AddDoubleQuote());
        }
    }
}