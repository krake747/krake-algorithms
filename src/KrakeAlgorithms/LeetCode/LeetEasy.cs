using System.Numerics;
using System.Text;

namespace KrakeAlgorithms.LeetCode;

public static class LeetEasy
{
    /// <remarks>
    ///     https://leetcode.com/problems/two-sum/
    /// </remarks>
    public static int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var rest = target - nums[i];
            if (map.TryGetValue(rest, out var value))
            {
                return [value, i];
            }

            _ = map.TryAdd(nums[i], i);
        }

        return [];
    }

    /// <remarks>
    ///     https://leetcode.com/problems/palindrome-number/
    /// </remarks>
    public static bool IsPalindrome(int x)
    {
        var s = x.ToString();
        var r = string.Create(s.Length, s, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars.Reverse();
        });

        return s == r;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/roman-to-integer/
    /// </remarks>
    public static int RomanToInt(string s)
    {
        var result = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var value = RomanValue(s[i]);
            if (i + 1 < s.Length && value < RomanValue(s[i + 1]))
            {
                result -= value;
            }
            else
            {
                result += value;
            }
        }

        return result;

        static int RomanValue(char c) => c switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new ArgumentException("Invalid Roman numeral", nameof(c))
        };
    }

    /// <remarks>
    ///     https://leetcode.com/problems/longest-common-prefix/description/
    /// </remarks>
    public static string LongestCommonPrefix(string[] strs)
    {
        var prefix = string.Empty;
        var inputs = strs.Order().ToArray();
        for (var i = 0; i < inputs[0].Length; i++)
        {
            var c = inputs[0][i];
            if (inputs.Any(s => s[i] != c))
            {
                return prefix;
            }

            prefix += c;
        }

        return prefix;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/valid-parentheses/
    /// </remarks>
    public static bool IsValidParentheses(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (Open(c))
            {
                stack.Push(c);
            }
            else if (Close(c) && stack.Count > 0 && c == Pair(stack.Peek()))
            {
                stack.Pop();
            }
            else
            {
                return false;
            }
        }

        return stack.Count is 0;

        static bool Open(char c) => c is '(' or '[' or '{';
        static bool Close(char c) => c is ')' or ']' or '}';

        static char Pair(char c) => c switch
        {
            '(' => ')',
            '[' => ']',
            '{' => '}',
            _ => c
        };
    }

    // /// <remarks>
    // /// https://leetcode.com/problems/merge-two-sorted-lists/
    // /// </remarks>
    // public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    // {
    //     while (list1.Next is not null || list2.Next is not null)
    //     {
    //         
    //     }
    //     
    //     return new ListNode();
    // }

    /// <remarks>
    ///     https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    /// </remarks>
    /// >
    public static int RemoveDuplicated(int[] nums)
    {
        if (nums.Length < 2)
        {
            return nums.Length;
        }

        var j = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] != nums[i])
            {
                nums[j++] = nums[i];
            }
        }

        return j;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/remove-element/
    /// </remarks>
    public static int RemoveElement(int[] nums, int val)
    {
        var len = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[len++] = nums[i];
            }
        }

        return len;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/
    /// </remarks>
    public static int StrStr(string haystack, string needle)
    {
        for (var i = 0; i < haystack.Length + 1 - needle.Length; i++)
        {
            if (haystack.Substring(i, needle.Length) == needle)
            {
                return i;
            }
        }

        return -1;
    }

    public static int StrStr2(string haystack, string needle) =>
        haystack.IndexOf(needle, StringComparison.InvariantCulture);

    /// <remarks>
    ///     https://leetcode.com/problems/search-insert-position/description/
    /// </remarks>
    public static int SearchInsert(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length;
        do
        {
            var mid = low + (high - low) / 2;
            var value = nums[mid];
            if (value == target)
            {
                return mid;
            }

            if (value > target)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        } while (low < high);

        return low;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/search-insert-position/description/
    /// </remarks>
    public static int LengthOfLastWord(string s)
    {
        var isChar = false;
        var len = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (char.IsLetter(s[i]))
            {
                isChar = true;
                len++;
            }
            else
            {
                if (isChar)
                {
                    return len;
                }
            }
        }

        return len;
    }

    public static int[] PlusOne(int[] digits)
    {
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            if (++digits[i] is 10)
            {
                digits[i] = 0;
            }
            else
            {
                return digits;
            }
        }

        return [1, ..digits];
    }

    /// <remarks>
    ///     https://leetcode.com/problems/add-binary/description/
    /// </remarks>
    public static string AddBinary(string a, string b)
    {
        var sb = new StringBuilder();
        var carry = 0;
        for (int i = a.Length - 1, j = b.Length - 1; i >= 0 || j >= 0; i--, j--)
        {
            var x = i >= 0 ? a[i] - '0' : 0;
            var y = j >= 0 ? b[j] - '0' : 0;
            var sum = x + y + carry;

            if (sum > 1)
            {
                carry = 1;
                sb.Insert(0, sum % 2);
            }
            else
            {
                carry = 0;
                sb.Insert(0, sum);
            }
        }

        if (carry is 1)
        {
            sb.Insert(0, '1');
        }

        return sb.ToString();
    }

    /// <remarks>
    ///     https://leetcode.com/problems/sqrtx/description/
    /// </remarks>
    public static int MySqrt(int x)
    {
        var low = 0;
        var high = x;
        var mid = high / 2;
        do
        {
            var value = (long)mid * mid;
            if (value == x)
            {
                return mid;
            }

            if (value > x)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }

            mid = (high + low) / 2;
        } while (low <= high);

        return mid;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/climbing-stairs/
    /// </remarks>
    public static int ClimbStairs(int n)
    {
        if (n is 1)
        {
            return 1;
        }

        var first = 1;
        var second = 2;
        for (var i = 3; i <= n; i++)
        {
            var third = first + second;
            first = second;
            second = third;
        }

        return second;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/merge-sorted-array/
    /// </remarks>
    public static void MergeSortedArray(int[] nums1, int m, int[] nums2, int n)
    {
        var i = m - 1;
        var j = n - 1;
        var k = m + n - 1;
        while (j >= 0)
        {
            if (i >= 0 && nums1[i] > nums2[j])
            {
                nums1[k--] = nums1[i--];
            }
            else
            {
                nums1[k--] = nums2[j--];
            }
        }
    }

    /// <remarks>
    ///         https://leetcode.com/problems/pascals-triangle/
    /// </remarks>
    public static IList<IList<int>> PascalsTriangle(int numRows)
    {
        var triangle = new List<IList<int>>();
        for (var i = 0; i < numRows; i++)
        {
            triangle.Add(new List<int>());
            for (var j = 0; j < i + 1; j++)
            {
                if (j is 0 || j == i)
                {
                    triangle[i].Add(1);
                }
                else
                {
                    triangle[i].Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
                }
            }
        }

        return triangle;
    }
    
    /// <remarks>
    ///     https://leetcode.com/problems/pascals-triangle-ii
    /// </remarks>
    public static IList<int> PascalsTriangleRow(int rowIndex) => 
        PascalsTriangle(rowIndex + 1)[rowIndex];

    /// <remarks>
    ///     https://leetcode.com/problems/pascals-triangle-ii
    /// </remarks>
    public static IList<int> PascalsTriangleRow2(int rowIndex)
    {
        var row = new List<int>();
        for (var i = 0; i < rowIndex + 1; i++)
        {
            row.Add((int)Combination(rowIndex, i));
        }

        return row;

        static BigInteger Combination(BigInteger n, BigInteger k) => 
            Factorial(n, 1) / (Factorial(k, 1) * Factorial(n - k, 1));
        
        static BigInteger Factorial(BigInteger n, BigInteger acc) => n switch
        {
            _ when n == 0 => acc,
            _ => Factorial(n - 1, acc * n)
        };
    }

    /// <remarks>
    ///     https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    /// </remarks>
    public static int BestTimeToBuyAndSellStock(int[] prices)
    {
        if (prices.Length is 0)
        {
            return 0;
        }

        var minBuy = prices[0];
        var profit = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            minBuy = Math.Min(minBuy, prices[i]);
            profit = Math.Max(profit, prices[i] - minBuy);
        }
        
        return profit;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/valid-palindrome/
    /// </remarks>
    public static bool IsValidPalindrome(string s)
    {
        var chars = s.ToLower().Where(c => char.IsLetter(c) || char.IsDigit(c)).ToArray();
        var s1 = new string(chars);
        var r = string.Create(s1.Length, s1, static (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars.Reverse();
        });
        
        return s1 == r;
    }
    
    /// <remarks>
    ///     https://leetcode.com/problems/single-number/
    /// </remarks>
    public static int SingleNumber(int[] nums)
    {
        var memo = new Dictionary<int, int>();
        foreach (var i in nums)
        {
            if (memo.TryAdd(i, 1) is false)
            {
                memo[i] += 1;
            }
        }
        
        return memo.MinBy(x => x.Value).Key;
    }
    
    public static int SingleNumber2(int[] nums)
    {
        return nums.Aggregate(0, (current, i) => current ^ i);
    }
    
    /// <remarks>
    ///     https://leetcode.com/problems/excel-sheet-column-title/
    /// </remarks>
    public static string ExcelConvertToTitle(int columnNumber)
    {
        var sb = new StringBuilder();
        do
        {
            columnNumber--;
            var remainder = columnNumber % 26;
            sb.Insert(0, (char)('A' + remainder));
            columnNumber /= 26;
        } while (columnNumber is not 0);
        
        return sb.ToString();
    }
    
    /// <remarks>
    ///     https://leetcode.com/problems/majority-element/
    /// </remarks>
    public static int MajorityElement(int[] nums)
    {
        var count = 0;
        var majority = 0;
        foreach (var num in nums)
        {
            if (count is 0)
            {
                majority = num;
            }

            count += num == majority ? 1 : -1;
        }

        return majority;
        
        // var n = nums.Length;
        // var limit = n / 2;
        // var memo = new Dictionary<int, int>();
        // foreach (var num in nums)
        // {
        //     if (memo.TryAdd(num, 1) is false)
        //     {
        //         memo[num] += 1;
        //     }
        // }
        //         
        // return memo.MaxBy(x => x.Value > limit).Key;
    }
    
    /// <remarks>
    ///     https://leetcode.com/problems/ransom-note/
    /// </remarks>
    public static bool CanConstruct(string ransomNote, string magazine)
    {
        var groupNote = ransomNote
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        var groupMagazine = magazine
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        return groupNote.All(x => groupMagazine.ContainsKey(x.Key) && groupMagazine[x.Key] >= x.Value);
    }

    /// <remarks>
    ///     https://leetcode.com/problems/fizz-buzz/description/
    /// </remarks>
    public static IList<string> FizzBuzz(int n)
    {
        var arr = new string[n];
        for (var i = 0; i < n; i++)
        {
            arr[i] = Fizzbuzz(i + 1);
        }

        return arr;

        static string Fizzbuzz(int x) => (x % 5, x % 3) switch
        {
            (0, 0) => "FizzBuzz",
            (_, 0) => "Fizz",
            (0, _) => "Buzz",
            _ => x.ToString()
        };
    }

    /// <remarks>
    ///     https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/
    /// </remarks>
    public static int NumberOfSteps(int num)
    {
        var i = 0;
        while (num is not 0)
        {
            if (num % 2 is 0)
            {
                num /= 2;
            }
            else
            {
                num -= 1;
            }

            i++;
        }

        return i;
    }

    /// <remarks>
    ///     https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix/
    /// </remarks>
    public static int[] KWeakestRows(int[][] mat, int k)
    {
        return Enumerable.Range(0, mat.GetLength(0))
            .Select(r => (Row: r, Soldiers: mat[r].Count(i => i is 1)))
            .OrderBy(r => r.Soldiers)
            .ThenBy(r => r.Row)
            .Select(r => r.Row)
            .Take(k)
            .ToArray();
    }
}

/// <summary>
///     Definition for singly-linked list.
/// </summary>
/// <param name="val"></param>
/// <param name="next"></param>
public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public ListNode? Next = next;
    public int Val = val;
}