using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using Perfolizer.Horology;
using static FSharpCollections.Examples.Pervasives;

namespace Benchmarks
{
    public class FastAndDirtyConfig : ManualConfig
    {
        public FastAndDirtyConfig()
        {
            var fastJob =
                Job.Default
                    .WithLaunchCount(1) // benchmark process will be launched only once
                    .WithIterationTime(TimeInterval.FromMilliseconds(100)) // 100ms per iteration
                    .WithWarmupCount(3) // 3 warmup iteration
                    .WithIterationCount(3); // 3 target iteration

            AddJob(fastJob);
        }
    }

    [Config(typeof(FastAndDirtyConfig))]
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Benchmark]
        public void Scenario1()
        {
        }

        [Benchmark]
        public void Scenario2()
        {
        }
    }
    
    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
