using System.Text;

namespace Tests;

internal static class Data
{

    static readonly string abcd = "abc𝚫";
    static readonly string emoji = "👍🐶";
    static readonly string efghi = "éfghi";

    static string RandomString(int length)
    {
        var b = new byte[length];
        return Encoding.UTF8.GetString(b);
    }

    static readonly Random rnd = new();

    internal static readonly string[] TestSeparators = ["", " ", ",", ", ", "🐶", "𝚫", "🌏👍", abcd, emoji, efghi, RandomString(4)];

    internal static IEnumerable<string> TestStrings
    {
        get
        {
            yield return "";
            yield return abcd;
            yield return emoji;
            yield return efghi;

            foreach (string sep in TestSeparators)
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
    }
}
