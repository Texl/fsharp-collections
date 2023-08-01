using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using Perfolizer.Horology;

namespace Benchmarks;

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
