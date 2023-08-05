using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using DbContextSaveChanges.Services;

namespace DbContextSaveChanges.Benchmarks.DbContextMethodBenchmarks
{
    //find benchmark results at: ...\DbContextSaveChanges\DbContextSaveChanges.Benchmarks\bin\Release\net7.0\BenchmarkDotNet.Artifacts\results
    [SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 5, iterationCount: 5, invocationCount: 5, id: "FastAndDirtyJob")]
    [MemoryDiagnoser]
    public class InsertMethodBenchmark
    {
        InsertMethodService service = new InsertMethodService();

        [Benchmark]
        public void SaveEachListOfRecords()
        {
            service.UseAdd();
        }

        [Benchmark(Baseline = true)]
        public void SaveListOfRecordsAtOnce()
        {
            service.UseAddRange();
        }

    }
}
