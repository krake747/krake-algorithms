namespace KrakeAlgorithms;

public static class MathAlgorithms
{
    public static long FibonacciSlow(long n) =>
        n < 2L ? n : FibonacciSlow(n - 2L) + FibonacciSlow(n - 1L);

    public static long Fibonacci(long n)
    {
        return Loop(n, 0L, 1L);

        static long Loop(long n, long a, long b) => n switch
        {
            0L => a,
            1L => b,
            _ => Loop(n - 1L, b, a + b),
        };
    }
}