using BenchmarkDotNet.Running;
using DbContextSaveChanges.Benchmarks.DbContextMethodBenchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<InsertMethodBenchmark>();

        Console.WriteLine("Benchmark process completed");
    }
}