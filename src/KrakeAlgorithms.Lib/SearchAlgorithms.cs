using System.Numerics;

namespace KrakeAlgorithms.Lib;

public static class SearchAlgorithms
{
    public static bool LinearSearch<T>(T[] haystack, T needle)
        where T : INumber<T>
    {
        for (var i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle)
            {
                return true;
            }
        }

        return false;
    }

    public static bool BinarySearch<T>(T[] haystack, T needle)
        where T : INumber<T>
    {
        var low = 0;
        var high = haystack.Length;
        do
        {
            var mid = low + (high - low) / 2;
            var value = haystack[mid];
            if (value == needle)
            {
                return true;
            }

            if (value > needle)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        } while (low < high);

        return false;
    }
}