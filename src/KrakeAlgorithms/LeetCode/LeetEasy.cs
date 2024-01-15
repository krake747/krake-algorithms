using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace KrakeAlgorithms.LeetCode;

public static class LeetEasy
{
    /// <remarks>
    /// https://leetcode.com/problems/two-sum/
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
    /// https://leetcode.com/problems/palindrome-number/
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
    /// https://leetcode.com/problems/roman-to-integer/
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
    /// https://leetcode.com/problems/longest-common-prefix/description/
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
    /// https://leetcode.com/problems/valid-parentheses/
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
    /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    /// </remarks>>
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
    /// https://leetcode.com/problems/remove-element/
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
    /// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/
    /// </remarks>
    public static int StrStr(string haystack, string needle)
    {
        for (var i = 0; i < haystack.Length + 1 - needle.Length; i++)
        {
            if (haystack.Substring(i,  needle.Length) == needle)
            {
                return i;
            }
        }

        return -1;
    }
    
    public static int StrStr2(string haystack, string needle) =>
        haystack.IndexOf(needle, StringComparison.InvariantCulture);

    /// <remarks>
    /// https://leetcode.com/problems/search-insert-position/description/
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
    /// https://leetcode.com/problems/search-insert-position/description/
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
}

/// <summary>
/// Definition for singly-linked list.
/// </summary>
/// <param name="val"></param>
/// <param name="next"></param>
public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int Val = val;
    public ListNode? Next = next;
}