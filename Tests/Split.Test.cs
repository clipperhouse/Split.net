namespace Tests;

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
}
