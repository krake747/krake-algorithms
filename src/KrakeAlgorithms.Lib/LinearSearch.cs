using System.Numerics;

namespace KrakeAlgorithms.Lib;

public static class SearchAlgorithms
{
    public static bool LinearSearch<T>(IList<T> haystack, T needle)
        where T : INumber<T>
    {
        for (var i = 0; i < haystack.Count; i++)
        {
            if (haystack[i] == needle)
            {
                return true;
            }
        }

        return false;
    }
}
