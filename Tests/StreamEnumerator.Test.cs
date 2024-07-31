namespace Tests;

using System.Text;
using Split;
using Xunit;

public partial class SplitTests
{
    [Fact]
    public void StreamMatchesStatic()
    {
        var example = "abcdefghijk lmnopq r stu vwxyz; ABC DEFG HIJKL MNOP Q RSTUV WXYZ! 你好，世界.";
        var examples = new List<string>()
        {
            example,											// smaller than the buffer
			string.Concat(Enumerable.Repeat(example, 999))		// larger than the buffer
		};

        foreach (var input in examples)
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            // Chars
            {
                using var stream = new MemoryStream(bytes);
                using var reader = new StreamReader(stream);
                var staticTokens = Split.Chars(input, ' ');
                var streamTokens = Split.Chars(reader, ' ');

                while (staticTokens.MoveNext())
                {
                    streamTokens.MoveNext();

                    var expected = staticTokens.Current.ToString();
                    var got = streamTokens.Current.ToString();

                    Assert.Equal(expected, got);
                }

                Assert.False(staticTokens.MoveNext());
                Assert.False(streamTokens.MoveNext());
            }

            // Bytes
            {
                using var stream = new MemoryStream(bytes);

                var staticTokens = Split.Bytes(bytes, (byte)' ');
                var streamTokens = Split.Bytes(stream, (byte)' ');

                while (staticTokens.MoveNext())
                {
                    streamTokens.MoveNext();

                    var expected = Encoding.UTF8.GetString(staticTokens.Current);
                    var got = Encoding.UTF8.GetString(streamTokens.Current);

                    Assert.Equal(expected, got);
                }

                Assert.False(staticTokens.MoveNext());
                Assert.False(streamTokens.MoveNext());
            }
        }
    }

    // [Fact]
    // public void SetStream()
    // {
    //     var input = "Hello, how are you?";
    //     var bytes = Encoding.UTF8.GetBytes(input);
    //     using var stream = new MemoryStream(bytes);

    //     var tokens = Split.Bytes(stream, );

    //     var first = new List<string>();
    //     foreach (var token in tokens)
    //     {
    //         var s = Encoding.UTF8.GetString(token);
    //         first.Add(s);
    //     }

    //     Assert.That(first, Has.Count.GreaterThan(1));   // just make sure it did the thing

    //     using var stream2 = new MemoryStream(bytes);

    //     tokens.SetStream(stream2);

    //     var second = new List<string>();
    //     foreach (var token in tokens)
    //     {
    //         var s = Encoding.UTF8.GetString(token);
    //         second.Add(s);
    //     }

    //     Assert.That(first.SequenceEqual(second));
    // }

    // [Test]
    // public void SetStreamReader()
    // {
    //     var input = "Hello, how are you?";
    //     var bytes = Encoding.UTF8.GetBytes(input);
    //     using var stream = new MemoryStream(bytes);
    //     using var reader = new StreamReader(stream);

    //     var tokens = Split.Words(reader);

    //     var first = new List<string>();
    //     foreach (var token in tokens)
    //     {
    //         var s = token.ToString();
    //         first.Add(s);
    //     }

    //     Assert.That(first, Has.Count.GreaterThan(1));   // just make sure it did the thing

    //     using var stream2 = new MemoryStream(bytes);
    //     using var reader2 = new StreamReader(stream2);

    //     tokens.SetStream(reader2);

    //     var second = new List<string>();
    //     foreach (var token in tokens)
    //     {
    //         var s = token.ToString();
    //         second.Add(s);
    //     }

    //     Assert.That(first.SequenceEqual(second));
    // }

    // [Test]
    // public void StreamEnumerator()
    // {
    //     var input = "Hello, how are you?";
    //     var bytes = Encoding.UTF8.GetBytes(input);
    //     using var stream = new MemoryStream(bytes);

    //     var tokens = Split.Words(stream);

    //     var first = new List<string>();
    //     while (tokens.MoveNext())
    //     {
    //         var s = tokens.Current.ToString();
    //         first.Add(s);
    //     }

    //     Assert.That(first, Has.Count.GreaterThan(1));   // just make sure it did the thing

    //     using var stream2 = new MemoryStream(bytes);
    //     var tokens2 = Split.Words(stream2);

    //     var second = new List<string>();
    //     foreach (var token in tokens2)
    //     {
    //         var s = token.ToString();
    //         second.Add(s);
    //     }
    //     Assert.That(first.SequenceEqual(second));
    // }


    // [Test]
    // public void StreamToList()
    // {
    //     var example = "abcdefghijk lmnopq r stu vwxyz; ABC DEFG HIJKL MNOP Q RSTUV WXYZ! 你好，世界.";
    //     var bytes = Encoding.UTF8.GetBytes(example);
    //     using var stream = new MemoryStream(bytes);

    //     var list = Split.Words(stream).ToList();

    //     stream.Seek(0, SeekOrigin.Begin);
    //     var tokens = Split.Words(stream);

    //     var i = 0;
    //     foreach (var token in tokens)
    //     {
    //         Assert.That(token.SequenceEqual(list[i]));
    //         i++;
    //     }

    //     Assert.That(list, Has.Count.EqualTo(i), "ToList should return the same number of tokens as iteration");

    //     var threw = false;
    //     tokens.MoveNext();
    //     try
    //     {
    //         tokens.ToList();
    //     }
    //     catch (InvalidOperationException)
    //     {
    //         threw = true;
    //     }
    //     Assert.That(threw, Is.True, "Calling ToList after iteration has begun should throw");
    // }

    // [Test]
    // public void StreamToArray()
    // {
    //     var example = "abcdefghijk lmnopq r stu vwxyz; ABC DEFG HIJKL MNOP Q RSTUV WXYZ! 你好，世界.";
    //     var bytes = Encoding.UTF8.GetBytes(example);
    //     using var stream = new MemoryStream(bytes);

    //     var list = Split.Words(stream).ToList();

    //     stream.Seek(0, SeekOrigin.Begin);
    //     var tokens = Split.Words(stream);

    //     var i = 0;
    //     foreach (var token in tokens)
    //     {
    //         Assert.That(token.SequenceEqual(list[i]));
    //         i++;
    //     }

    //     Assert.That(list, Has.Count.EqualTo(i), "ToArray should return the same number of tokens as iteration");

    //     var threw = false;
    //     tokens.MoveNext();
    //     try
    //     {
    //         tokens.ToArray();
    //     }
    //     catch (InvalidOperationException)
    //     {
    //         threw = true;
    //     }
    //     Assert.That(threw, Is.True, "Calling ToArray after iteration has begun should throw");
    // }

    // [Test]
    // public void Position()
    // {
    //     var example = "abcdefghi jklmnopqr stu vwxyz; ABC DEFG HIJKL MNOP Q RSTUV WXYZ! 你好，世界.";
    //     var bytes = Encoding.UTF8.GetBytes(example);

    //     {
    //         using var stream = new MemoryStream(bytes);
    //         var tokens = Split.Words(stream, minBufferBytes: 8);
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(0));    // ab...
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(9));    // <space>
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(10));   // jk...
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(19));   // <space>
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(20));   // stu...
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(23));   // <space>
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(24));   // vw...
    //     }

    //     {
    //         using var stream = new MemoryStream(bytes);
    //         var tokens = Split.Words(stream, minBufferBytes: 8, options: Options.OmitWhitespace);
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(0));        // ab...
    //         // tokens.MoveNext();
    //         // Assert.That(tokens.Position, Is.EqualTo(9));     // <space>
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(10));       // jk...
    //         // tokens.MoveNext();
    //         // Assert.That(tokens.Position, Is.EqualTo(19));    // <space>
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(20));       // stu...
    //         // tokens.MoveNext();
    //         // Assert.That(tokens.Position, Is.EqualTo(23));    // <space>
    //         tokens.MoveNext();
    //         Assert.That(tokens.Position, Is.EqualTo(24));       // vw...
    //     }
    // }
}
