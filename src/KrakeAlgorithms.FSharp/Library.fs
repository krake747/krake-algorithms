namespace KrakeAlgorithms.FSharp

module Algorithms =
    let fib (n: int64) =
        let rec loop n (a, b) =
            match n with
            | 0L -> a
            | 1L -> b
            | n -> loop (n - 1L) (b, a + b)
        loop n (0L, 1L)
       