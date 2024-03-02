// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using KrakeAlgorithms;
using KrakeAlgorithms.FSharp;

Console.WriteLine("Hello, World!");

var sw = Stopwatch.StartNew();

var fibFSharp = Algorithms.fib(50);

Console.WriteLine($"F# Fib results in {fibFSharp} in {sw.ElapsedMilliseconds}ms");

sw.Reset();

sw.Start();

var fibCSharp = MathAlgorithms.Fibonacci(50);

Console.WriteLine($"C# Fib results in {fibCSharp} in {sw.ElapsedMilliseconds}ms");

sw.Reset();

sw.Start();

var factorial = MathAlgorithms.Factorial(5);

Console.WriteLine($"C# Factorial results in {factorial} in {sw.ElapsedMilliseconds}ms");

