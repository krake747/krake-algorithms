using BenchmarkDotNet.Attributes;
using KrakeAlgorithms.Lib;

namespace KrakeAlgorithms.Benchmarks;

[MemoryDiagnoser]
public sealed class SearchBenchmarks
{
    private int[] _sample = Array.Empty<int>();

    [Params(100)] public int Size { get; set; }

    [Params(78)] public int Value { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _sample = Enumerable.Range(1, Size).ToArray();
    }

    [Benchmark]
    public void LinearSearch() => SearchAlgorithms.LinearSearch(_sample, Value);

    [Benchmark]
    public void BinarySearch() => SearchAlgorithms.BinarySearch(_sample, Value);
}