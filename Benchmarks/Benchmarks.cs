using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Microsoft.FSharp.Collections;
using ArrayModule = Microsoft.FSharp.Collections.ArrayModule;
using ListModule = Microsoft.FSharp.Collections.ListModule;

namespace Benchmarks;

[Config(typeof(FastAndDirtyConfig))]
[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public List<int> List()
    {
        var list = new List<int>();

        for (var i = 0; i < 100_000; ++i)
        {
            list.Add(42);
        }

        return list;
    }

    [Benchmark]
    public List<int> EnumerableRangeToList()
    {
        return Enumerable.Repeat(42, 100_000).ToList();
    }

    [Benchmark]
    public int[] EnumerableRangeToArray()
    {
        return Enumerable.Repeat(42, 100_000).ToArray();
    }

    [Benchmark]
    public int[] NewArray()
    {
        var array = new int[100_000];
        for (var i = 0; i < array.Length; ++i)
        {
            array[i] = 42;
        }

        return array;
    }

    [Benchmark]
    public LinkedList<int> LinkedList()
    {
        var list = new LinkedList<int>();

        for (var i = 0; i < 100_000; ++i)
        {
            list.AddFirst(42);
        }

        return list;
    }

    [Benchmark]
    public FSharpList<int> FSharpList()
    {
        return ListModule.Replicate(100_000, 42);
    }
    
    [Benchmark]
    public int[] FSharpArrayZeroCreate()
    {
        int[] array = ArrayModule.ZeroCreate<int>(100_000);

        for (var i = 0; i < array.Length; ++i)
        {
            array[i] = 42;
        }

        return array;
    }

    [Benchmark]
    public int[] FSharpArray()
    {
        return ArrayModule.Replicate(100_000, 42);
    }
}
