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
    
    public static T[] MergeSort<T>(T[] a) 
        where T : INumber<T>
    {
        if (a.Length < 2)
        {
            return a;
        }

        var m = a.Length / 2;
        var lhs = SubArray(a, 0, m - 1);
        var rhs = SubArray(a, m, a.Length - 1);
        MergeSort(lhs);
        MergeSort(rhs);

        int i = 0, j = 0, k = 0;
        while (i < lhs.Length && j < rhs.Length)
        {
            if (lhs[i] < rhs[j])
            {
                a[k] = lhs[i++];
            }
            else
            {
                a[k] = rhs[j++];
            }

            k++;
        }

        while (i < lhs.Length)
        {
            a[k++] = lhs[i++];
        }
        
        while (j < rhs.Length)
        {
            a[k++] = rhs[j++];
        }
        
        return a;

        static T[] SubArray(T[] a, int si, int ei)
        {
            var len = ei - si + 1;
            var result = new T[len];
            Array.Copy(a, si, result, 0, len);;
            return result;
        }
    }

    public static T[] ShellSort<T>(T[] a) 
        where T : INumber<T>
    {
        for (var h = a.Length / 2; h > 0; h /= 2)
        {
            for (var i = h; i < a.Length; i++)
            {
                var j = i;
                var v = a[i];
                while (j >= h && a[j - h] > v)
                {
                    a[j] = a[j - h];
                    j -= h;
                }

                a[j] = v;
            }
        }
        
        return a;
    }
    
    public static T[] QuickSort<T>(T[] a) 
        where T : INumber<T>
    {
        return SortPart(a, 0, a.Length - 1);

        static T[] SortPart(T[] a, int l, int u)
        {
            if (l >= u)
            {
                return a;
            }

            var pivot = a[u];
            var j = l - 1;
            for (var i = l; i < u; i++)
            {
                if (a[i] >= pivot)
                {
                    continue;
                }

                j++;
                (a[j], a[i]) = (a[i], a[j]);
            }
            
            var p = j + 1;
            (a[p], a[u]) = (a[u], a[p]);
            SortPart(a, l, p - 1);
            SortPart(a, p + 1, u);

            return a;
        }
    }

    public static T[] HeapSort<T>(T[] a)
        where T : INumber<T>
    {
        return a;
    }
}