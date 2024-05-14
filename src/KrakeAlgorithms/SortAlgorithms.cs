using System.Numerics;

namespace KrakeAlgorithms;

public static class SortAlgorithms
{
    public static T[] SelectionSort<T>(T[] a)
        where T : INumber<T>
    {
        for (var i = 0; i < a.Length - 1; ++i)
        {
            var minIndex = i;
            var minValue = a[i];
            for (var j = i + 1; j < a.Length; ++j)
            {
                if (a[j] < minValue)
                {
                    minIndex = j;
                    minValue = a[j];
                }
            }

            (a[i], a[minIndex]) = (a[minIndex], a[i]);
        }
        
        return a;
    }
    
    public static T[] InsertionSort<T>(T[] a)
        where T : INumber<T>
    {
        for (var i = 1; i < a.Length; ++i)
        {
            var j = i;
            while (j > 0 && a[j] < a[j - 1])
            {
                (a[j], a[j - 1]) = (a[j - 1], a[j]);
                j--;
            }
        }
        
        return a;
    }

    public static T[] BubbleSort<T>(T[] a)
        where T : INumber<T>
    {
        for (var i = 0; i < a.Length; ++i)
        {
            for (var j = 0; j < a.Length - 1 - i; ++j)
            {
                if (a[j] > a[j + 1])
                {
                    (a[j], a[j + 1]) = (a[j + 1], a[j]);
                }
            }
        }

        return a;
    }

    public static T[] QuickSort<T>(T[] sample) => Array.Empty<T>();

    public static T[] MergeSort<T>(T[] sample) => Array.Empty<T>();

}