namespace Split;

internal delegate int Read<T>(T[] buffer, int offset, int count);

internal ref struct Buffer<T>
{
    /// <summary>
    /// Allows the active span of the array to move with reduced copying.
    /// </summary>
    Read<T> read;
    readonly int minItems = 0;
    readonly T[] storage;

    internal int start = 0;
    internal int end = 0;

    /// <summary>
    /// Indicates that the last read operation reached the end of the stream, i.e. the number of read items was zero.
    /// </summary>
    internal bool EOF;

    internal Buffer(Read<T> read, int minBuffer, T[]? storage = null)
    {
        this.read = read;
        this.minItems = minBuffer;
        if (storage != null && storage.Length < minBuffer)
        {
            throw new ArgumentException($"Storage ({typeof(T)}[{storage.Length}]) must be at least as large as minBuffer ({minBuffer}).");
        }
        storage ??= new T[minBuffer];
        this.storage = storage;
    }

    internal ReadOnlySpan<T> Contents
    {
        get
        {
            var len = end - start;
            if (len < minItems)
            {
                // Move the remaining unconsumed data to the start of the buffer
                Array.Copy(storage, start, storage, 0, end - start);
                end -= start;
                start = 0;

                if (!EOF)
                {
                    var read = this.read(storage, end, storage.Length - end);
                    if (read == 0)
                    {
                        EOF = true;
                    }
                    end += read;
                }
            }
            var result = storage.AsSpan(start, end - start);
            return result;
        }
    }

    internal void Consume(int consumed)
    {
        var remaining = end - start;
        if (consumed > remaining)
        {
            consumed = remaining;
        }

        start += consumed;
    }

    internal void SetRead(Read<T> read)
    {
        this.read = read;
        start = 0;
        end = 0;
    }
}
