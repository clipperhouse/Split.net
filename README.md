A more efficient splitter for bytes and strings, with a focus on zero allocation, in C#.

### Usage

```csharp
using Split.Extensions;

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
    Console.OpenStandardOutput().Write([.. split2, (byte)'\n']);
}
```

⚠️ _Not on Nuget just yet, clone for now_

### Performance

This package exists to save allocations on the hot path, if you are using something like `strings.Split` from the standard library.

This package:

```
| Method            | Mean      | Error     | StdDev   | Throughput   | Gen0    | Gen1   | Gen2   | Allocated |
|------------------ |----------:|----------:|---------:|------------- |--------:|-------:|-------:|----------:|
| SplitOn           |  92.68 us |  8.484 us | 0.465 us |   1.176 GB/s |       - |      - |      - |         - |
```

Standard library:

```
| Method            | Mean      | Error     | StdDev   | Throughput   | Gen0    | Gen1   | Gen2   | Allocated |
|------------------ |----------:|----------:|---------:|------------- |--------:|-------:|-------:|----------:|
| StringSplit       | 109.97 us | 13.953 us | 0.765 us |    .991 GB/s | 49.3164 | 0.3662 | 0.1221 |  413352 B |
```

### Techniques

This package does two things to achieve zero allocations. First, it lazily iterates over the splits, instead of collecting them into an array.

Second, those splits are `Span`s, which are a view into the underlying string, and can stay on the stack.

### Prior art

These are not original ideas! Here are a few other examples with a similar approach:

[`System.MemoryExtensions.SpanSplitEnumerator`](https://github.com/dotnet/runtime/pull/104534) (I started this package by forking SpanSplitEnumerator.)

[`Microsoft.Extensions.Primitives.StringTokenizer`](https://learn.microsoft.com/en-us/dotnet/core/extensions/primitives#the-stringtokenizer-type)

[`Microsoft.Toolkit.HighPerformance.Extensions.StringExtensions.Tokenize`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.toolkit.highperformance.extensions.stringextensions.tokenize?view=win-comm-toolkit-dotnet-6.1)

Each of the above is in the same ballpark of throughput and allocation as this package.

### Why use this package, then?

Well, it's in progress, but enhancements will include simpler UTF-8 support, as well as streams and readers.
