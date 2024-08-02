using System.Buffers;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Primitives;
using Microsoft.Toolkit.HighPerformance;
using Split.Extensions;

BenchmarkRunner.Run<Benchmark>();

[SimpleJob(launchCount: 1, warmupCount: 3, iterationCount: 3)]
[Config(typeof(Config))]
[MemoryDiagnoser]
public class Benchmark
{
	private class Config : ManualConfig
	{
		public Config()
		{
			AddColumn(new Throughput());
		}
	}

	static byte[] sample = [];
	static string sampleStr = "";
	Stream sampleStream = Stream.Null;

	public string FileName = "sample.txt";

	[GlobalSetup]
	public void Setup()
	{
		sample = File.ReadAllBytes("sample.txt");
		sampleStr = Encoding.UTF8.GetString(sample);
		sampleStream = new MemoryStream(sample);
	}

	static readonly char[] separators = [' ', '.'];

	[Benchmark]
	public void SplitOn()
	{
		var tokens = sampleStr.SplitOn(' ');

		foreach (var token in tokens)
		{
			// buffer.Append(token);
		}
	}

	char[] space = " ".ToCharArray();

	[Benchmark]
	public void StringTokenizer()
	{
		var tokenizer = new StringTokenizer(sampleStr, space);

		foreach (StringSegment segment in tokenizer)
		{
			// buffer.Append(segment.Value);
		}
	}

	[Benchmark]
	public void StringTokenize()
	{
		var tokenizer = sampleStr.Tokenize(' ');

		foreach (var token in tokenizer)
		{
			// buffer.Append(segment.Value);
		}
	}

	[Benchmark]
	public void StringSplit()
	{
		string[] tokenizer = sampleStr.Split(' ');

		foreach (string segment in tokenizer)
		{
			// buffer.Append(segment);
		}
	}

	static readonly SearchValues<char> search = SearchValues.Create(" ");
	[Benchmark]
	public void SplitSearchValues()
	{
		var tokens = sampleStr.SplitOnAny(search);
		foreach (var token in tokens)
		{
			// buffer.Append(token);
		}
	}

	[Benchmark]
	public void SplitStream()
	{
		sampleStream.Seek(0, SeekOrigin.Begin);
		var splits = sampleStream.SplitOn((byte)' ');
		foreach (var split in splits) { }
	}

	static readonly ArrayPool<byte> pool = ArrayPool<byte>.Shared;

	[Benchmark]
	public void SplitStreamArrayPool()
	{
		var storage = pool.Rent(4096);

		sampleStream.Seek(0, SeekOrigin.Begin);
		var splits = sampleStream.SplitOn((byte)' ', 2048, storage);
		foreach (var split in splits) { }

		pool.Return(storage);
	}
}
