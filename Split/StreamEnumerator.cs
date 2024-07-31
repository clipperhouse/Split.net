namespace Split;

using System.Buffers;
using System.Diagnostics;

/// <summary>
/// StreamEnumerator is a small data structure for splitting strings from Streams or TextReaders. It implements GetEnumerator.
/// </summary>
public ref struct StreamEnumerator<T> where T : IEquatable<T>
{
	internal Buffer<T> buffer;

	private SpanSplitEnumerator<T> en;

	internal StreamEnumerator(Buffer<T> buffer)
	{
		this.buffer = buffer;
	}

	internal StreamEnumerator(Buffer<T> buffer, T separator) : this(buffer)
	{
		en = MemoryExtensions.Split([], separator);
	}

	internal StreamEnumerator(Buffer<T> buffer, ReadOnlySpan<T> separator, bool treatAsSingleSeparator) : this(buffer)
	{
		en = MemoryExtensions.Split([], separator);
	}

	internal StreamEnumerator(Buffer<T> buffer, ReadOnlySpan<T> separator) : this(buffer)
	{
		en = MemoryExtensions.SplitAny([], separator);
	}

	internal StreamEnumerator(Buffer<T> buffer, SearchValues<T> searchValues) : this(buffer)
	{
		en = MemoryExtensions.SplitAny([], searchValues);
	}

	public bool MoveNext()
	{
		if (!buffer.EOF)
		{
			buffer.Consume(en.Position);    // previous tokens
			en.SetText(buffer.Contents);
		}
		return en.MoveNext();
	}

	public ReadOnlySpan<T> Current => en.input[en.start..en.end];

	public StreamEnumerator<T> GetEnumerator() => this;

	/// <summary>
	/// Iterates over all tokens and collects them into a List, allocating a new array for each token.
	/// </summary>
	/// <returns>List<byte[]> or List<char[]>, depending on the input.</returns>
	public List<T[]> ToList()
	{
		var result = new List<T[]>();
		foreach (var token in this)
		{
			result.Add(token.ToArray());
		}

		return result;
	}

	/// <summary>
	/// Iterates over all tokens and collects them into an Array, allocating a new array for each token.
	/// </summary>
	/// <returns>byte[][] or char[][], depending on the input.</returns>
	public T[][] ToArray()
	{
		return this.ToList().ToArray();
	}
}

public static class StreamExtensions
{
	/// <summary>
	/// Resets an existing StreamEnumerator with a new stream. You might choose this as an optimization, as it will re-use a buffer, avoiding allocations.
	/// </summary>
	/// <param name="stream">The new stream</param>
	public static void SetStream(ref this StreamEnumerator<byte> en, Stream stream)
	{
		en.buffer.SetRead(stream.Read);
	}

	/// <summary>
	/// Resets an existing StreamEnumerator with a new stream. You might choose this as an optimization, as it will re-use a buffer, avoiding allocations.
	/// </summary>
	/// <param name="stream">The new stream</param>
	public static void SetStream(ref this StreamEnumerator<char> en, TextReader stream)
	{
		en.buffer.SetRead(stream.Read);
	}
}
