namespace Tests;

using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using Split;

public partial class ReadOnlySpanTests
{
    [Fact]
    public void Readme()
    {
        var example = "Hello, 🌏 world. 你好，世界.";

        // The tokenizer can split words, graphemes or sentences.
        // It operates on strings, UTF-8 bytes, and streams.

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
    }
}