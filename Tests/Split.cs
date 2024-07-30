namespace Tests;

using System.Text;
using Split.Extensions;
using Xunit;

public class SplitTests
{
    static readonly string abcd = "abc𝚫";
    static readonly string emoji = "👍🐶";
    static readonly string efghi = "éfghi";

    static string RandomString(int length)
    {
        var b = new byte[length];
        return Encoding.UTF8.GetString(b);
    }

    readonly Random rnd = new();

    static readonly string[] testSeparators = ["", " ", ",", ", ", "🐶", "𝚫", "🌏👍", abcd, emoji, efghi, RandomString(4)];

    static IEnumerable<string> TestStrings()
    {
        yield return "";
        yield return abcd;
        yield return emoji;
        yield return efghi;

        foreach (string sep in testSeparators)
        {
            yield return sep;
            var center = abcd + sep + emoji + sep + efghi;
            yield return center;
            yield return sep + center;
            yield return center + sep;
            yield return sep + center + sep;
            yield return RandomString(15);
        }
    }

    [Fact]
    public void Strings()
    {
        foreach (string s in TestStrings())
        {
            foreach (var sep in testSeparators)
            {
                var got = s.SplitOn(sep).ToList().Select(g => new string(g));
                var expected = s.Split(sep);

                Assert.Equal(expected, got);
            }
        }
    }
}
