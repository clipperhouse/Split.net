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

        var splits = example.Split(" ");

        foreach (var split in splits)
        {
            Console.WriteLine(split);
        }

        /*
        Hello,🌏
        world.
        你好,
        世界.
        */

        var bytes = Encoding.UTF8.GetBytes(example);
        var separators = " ,."u8.ToArray();
        var splits2 = bytes.SplitOnAny(separators);

        foreach (var split2 in splits2)
        {
            Console.OpenStandardOutput().Write(split2);
        }
    }

    [Fact]
    public void Overloads()
    {
        // Just to avoid breaking the API, no actual tests

        var example = "foo";
        {
            char separator = ' ';
            Split.Chars(example, separator);

            var separators = ". ";
            Split.Chars(example, separators);
            Split.CharsAny(example, separators);

            var search = SearchValues.Create(separators);
            Split.CharsAny(example, search);
        }

        var bytes = Encoding.UTF8.GetBytes(example);
        {
            var stream = new MemoryStream(bytes);

            byte separator = (byte)' ';
            Split.Bytes(bytes, separator);
            Split.Bytes(stream, separator);

            var separators = ". "u8;
            Split.Bytes(bytes, separators);
            Split.BytesAny(bytes, separators);
            Split.Bytes(stream, separators);
            Split.BytesAny(stream, separators);

            var search = SearchValues.Create(separators);
            Split.BytesAny(bytes, search);
            Split.BytesAny(stream, search);
        }
    }

    [Fact]
    public void Extensions()
    {
        // Just to avoid breaking the API, no actual tests

        var example = "foo";
        var bytes = Encoding.UTF8.GetBytes(example);
        var stream = new MemoryStream(bytes);

        {
            byte separator = (byte)' ';

            var this1 = bytes;
            var this2 = bytes.AsSpan();
            ReadOnlySpan<byte> this3 = this2;
            var this4 = stream;

            this1.SplitOn(separator);
            this2.SplitOn(separator);
            this3.SplitOn(separator);
            this4.SplitOn(separator);

            var separators = Encoding.UTF8.GetBytes(". ");
            ReadOnlySpan<byte> rsep = separators.AsSpan();

            this1.SplitOn(rsep);
            this2.SplitOn(rsep);
            this3.SplitOn(rsep);
            this4.SplitOn(rsep);

            this1.SplitOnAny(rsep);
            this2.SplitOnAny(rsep);
            this3.SplitOnAny(rsep);
            this4.SplitOnAny(rsep);

            var search = SearchValues.Create(separators);
            this1.SplitOnAny(search);
            this2.SplitOnAny(search);
            this3.SplitOnAny(search);
            this4.SplitOnAny(search);
        }

        {
            char separator = ' ';

            var this1 = example;
            Span<char> this2 = new(this1.ToCharArray());
            ReadOnlySpan<char> this3 = this2;
            var this4 = this1.ToCharArray();
            var this5 = new StreamReader(stream);

            this1.SplitOn(separator);
            this2.SplitOn(separator);
            this3.SplitOn(separator);
            this4.SplitOn(separator);

            var separators1 = ". ";
            var separators2 = separators1.AsSpan();
            ReadOnlySpan<char> separators3 = separators2;
            var separators4 = separators1.ToCharArray();

            this1.SplitOn(separators1);
            this2.SplitOn(separators1);
            this3.SplitOn(separators1);
            this4.SplitOn(separators1);
            this5.SplitOn(separators1);

            this1.SplitOnAny(separators1);
            this2.SplitOnAny(separators1);
            this3.SplitOnAny(separators1);
            this4.SplitOnAny(separators1);
            this5.SplitOnAny(separators1);

            this1.SplitOnAny(separators2);
            this2.SplitOnAny(separators2);
            this3.SplitOnAny(separators2);
            this4.SplitOnAny(separators2);
            this5.SplitOnAny(separators2);

            this1.SplitOnAny(separators3);
            this2.SplitOnAny(separators3);
            this3.SplitOnAny(separators3);
            this4.SplitOnAny(separators3);
            this5.SplitOnAny(separators3);

            this1.SplitOnAny(separators4);
            this2.SplitOnAny(separators4);
            this3.SplitOnAny(separators4);
            this4.SplitOnAny(separators4);
            this5.SplitOnAny(separators4);

            var search = SearchValues.Create(separators1);
            this1.SplitOnAny(search);
            this2.SplitOnAny(search);
            this3.SplitOnAny(search);
            this4.SplitOnAny(search);
            this5.SplitOnAny(search);
        }

    }
}
