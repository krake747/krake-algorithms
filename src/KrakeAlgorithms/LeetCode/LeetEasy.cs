namespace KrakeAlgorithms.LeetCode;

public static class LeetEasy
{
    
    /// <remarks>https://leetcode.com/problems/roman-to-integer/</remarks>
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
}