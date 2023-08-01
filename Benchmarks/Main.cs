namespace Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks>();
    }
}
