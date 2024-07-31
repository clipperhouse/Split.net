namespace Tests;

using System.ComponentModel;
using System.Text;
using Split.Extensions;
using Xunit;

public partial class SplitTests
{
    [Fact]
    public void MatchStlibStringSplit()
    {
        foreach (string s in Data.TestStrings)
        {
            foreach (var sep in Data.TestSeparators)
            {
                var got = s.SplitOn(sep).ToList().Select(g => new string(g));
                var expected = s.Split(sep);

                Assert.Equal(expected, got);

            }
        }
    }

    [Fact]
    public void Any()
    {
        Console.WriteLine("Any:");
        var example = "Hello, 🌏 world. 你好, 世界. ";
        var seps = " ,.".ToCharArray();

        var splits = example.SplitOnAny(seps).ToArray();

        // Note, when two seaprators are adjacent in the string, there is an empty split between them
        string[] expecteds = ["Hello", "", "🌏", "world", "", "你好", "", "世界", "", "",];

        var i = 0;
        foreach (var s in splits)
        {
            var actual = new string(s);
            var expected = expecteds[i];
            Assert.Equal(expected, actual);
            i++;
        }

    }
}
