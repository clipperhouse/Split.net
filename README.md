## Split.net

A more efficient splitter for bytes and strings, with a focus on zero allocation, in C#.

### Usage

```
dotnet add package SplitDotNet
```

```csharp
var example = "Hello, 🌏 world. 你好, 世界. ";

var splits = example.SplitOn(" ");

foreach (var split in splits)
{
    // split is a ReadOnlySpan<char>
}

var bytes = Encoding.UTF8.GetBytes(example);
var separators = " ,."u8.ToArray();
var splits2 = bytes.SplitOnAny(separators);

foreach (var split2 in splits2)
{
    // split2 is a ReadOnlySpan<byte>
}
```

### Performance

This package exists to save allocations on the hot path, if you are using something like `strings.Split` from the standard library. Benchmarks on ~100K of text:

```
| Method            | Mean      | Error    | StdDev   | Throughput | Gen0    | Gen1   | Gen2   | Allocated |
|------------------ |----------:|---------:|---------:|----------- |--------:|-------:|-------:|----------:|
| Split.net         |  91.68 us | 0.804 us | 0.712 us |  1.19 GB/s |       - |      - |      - |         - |
```

Standard library:

```
| Method            | Mean      | Error    | StdDev   | Throughput | Gen0    | Gen1   | Gen2   | Allocated |
|------------------ |----------:|---------:|---------:|----------- |--------:|-------:|-------:|----------:|
| string.Split      | 106.40 us | 0.138 us | 0.108 us |  1.02 GB/s | 49.3164 | 0.3662 | 0.1221 |  413352 B |
```

### Techniques

This package does two things to achieve zero allocations. First, it lazily iterates over the splits, instead of collecting them into an array.

Second, each split is a `Span`, which is a "view" into the underlying `string` or `byte[]`, and stays on the stack. [Here's a blog post](https://clipperhouse.com/split/).

### Data types

**`using Split.Extensions;`**

You will find `.SplitOn()` and `.SplitOnAny()` extension methods added to: `string`, `byte[]`, `char[]`, `(ReadOnly)Span<char|byte>`, `Stream` and `TextReader`/`StreamReader` .

**`using Split;`**

If you don't like all those extension methods hanging off your types:

You'll find `Split.Bytes()` and `Split.BytesAny()`, accepting `byte[]`, `(ReadOnly)Span<byte>` and `Stream`.

You'll find `Split.Chars()` and `Split.CharsAny()`, which can accept `string`, `char[]`, `(ReadOnly)Span<char>` and `TextReader`/`StreamReader`.

### Testing

We [test](https://github.com/clipperhouse/Split.net/tree/main/Tests) that Split.net returns identical results to `string.Split`, including various edge cases.

### Prior art

These are not original ideas! Here are a few other examples with a similar approach:

- [`SpanSplitEnumerator`](https://github.com/dotnet/runtime/pull/104534) (This Split.net package started as a fork of `SpanSplitEnumerator`)

- [`StringTokenizer`](https://learn.microsoft.com/en-us/dotnet/core/extensions/primitives#the-stringtokenizer-type)

- [`StringExtensions.Tokenize`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.toolkit.highperformance.extensions.stringextensions.tokenize?view=win-comm-toolkit-dotnet-6.1)

Each of the above is in the same ballpark of throughput and allocation as this package.

### Why use Split.net, then?

You might like the UTF-8 support, SplitAny, streams & readers, or heck maybe you just like the API. Feedback welcome.

### By the way

If you are splitting in order to get "words" from natural text, you may wish to use the Unicode definition of word boundaries, which I've implemented in [this package](https://github.com/clipperhouse/uax29.net).

I've also implemented these ideas [in Go](https://github.com/clipperhouse/split).
