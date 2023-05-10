using BenchmarkDotNet.Running;
using KrakeAlgorithms.Benchmarks;

var summary = BenchmarkRunner.Run<SearchBenchmarks>();