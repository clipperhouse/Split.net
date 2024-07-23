using System.Buffers;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Extensions;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Primitives;
using Microsoft.Toolkit.HighPerformance;
using Microsoft.Toolkit.HighPerformance.Extensions;
using Split;

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
			// AddDiagnoser(new EventPipeProfiler(EventPipeProfile.CpuSampling));
			// You can also use other profilers like:
			// AddDiagnoser(new EtwProfiler());
			// AddDiagnoser(new PerfCollectProfiler()); // for Linux
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

	[Benchmark]
	public void StringTokenizer()
	{
		StringBuilder buffer = new();

		var tokenizer = new StringTokenizer(sampleStr, [' ', '.']);

		foreach (StringSegment segment in tokenizer)
		{
			// buffer.Append(segment.Value);
		}
	}

	[Benchmark]
	public void StringTokenize()
	{
		StringBuilder buffer = new();

		var tokenizer = sampleStr.Tokenize(' ');

		foreach (var token in tokenizer)
		{
			// buffer.Append(segment.Value);
		}
	}

	[Benchmark]
	public void StringSplit()
	{
		StringBuilder buffer = new();

		string[] tokenizer = sampleStr.Split([' ', '.']);

		foreach (string segment in tokenizer)
		{
			// buffer.Append(segment);
		}
	}
	static readonly SearchValues<char> search = SearchValues.Create([' ', '.']);
	[Benchmark]
	public void SpanSplit()
	{
		StringBuilder buffer = new();

		var tokens = Span.SplitAny(sampleStr, search);
		foreach (var token in tokens)
		{
			// buffer.Append(token);
		}
	}
}
