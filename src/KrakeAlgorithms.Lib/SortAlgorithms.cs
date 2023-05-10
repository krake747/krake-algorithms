using System.Numerics;

namespace KrakeAlgorithms.Lib;

public static class SortAlgorithms
{
    public static T[] BubbleSort<T>(T[] array) 
        where T : INumber<T>
    {
        for (var i = 0; i < array.Length; ++i)
        {
            for (var j = 0; j < array.Length - 1 - i; ++j)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                }
            }
        }
        
        return array;
    }

    private static void Swap<T>(T[] array, int firstIndex, int secondIndex)
    {
        (array[firstIndex], array[secondIndex]) = (array[secondIndex], array[firstIndex]);
    }

    public static T[] QuickSort<T>(T[] sample)
    {
        return Array.Empty<T>(); 
    }
    
    public static T[] MergeSort<T>(T[] sample)
    {
        return Array.Empty<T>();
    }
    
    public static T[] SelectionSort<T>(T[] sample)
    {
        return Array.Empty<T>();
    }
    
    public static T[] InsertionSort<T>(T[] sample)
    {
        return Array.Empty<T>();
    }
}