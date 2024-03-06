using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;
using KrakeAlgorithms.LeetCode;

namespace KrakeAlgorithms.Tests.Unit.LeetCode;

public sealed class LeetEasyTests
{
    [Fact]
    public void TwoSum()
    {
        // Arrange
        int[] input = [3, 2, 4];
        const int target = 6;

        // Act
        var result = LeetEasy.TwoSum(input, target);

        // Assert
        result.Should().Equal(1, 2);
    }

    [Fact]
    public void IsPalindrome()
    {
        // Arrange
        const int input = 121;

        // Act
        var result = LeetEasy.IsPalindrome(input);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void RomanToInteger()
    {
        // Arrange
        const string input = "MCMXCIV";
        const int expected = 1994;

        // Act
        var result = LeetEasy.RomanToInt(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void LongestCommonPrefix()
    {
        // Arrange
        string[] input = ["flower", "flow", "flight"];
        const string expected = "fl";

        // Act
        var result = LeetEasy.LongestCommonPrefix(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsValidParentheses()
    {
        // Arrange
        const string input = "([)]";

        // Act
        var result = LeetEasy.IsValidParentheses(input);

        // Assert
        result.Should().BeFalse();
    }

    // [Fact]
    // public void MergeTwoLists()
    // {
    //     // Arrange
    //     var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
    //     var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
    //     var expected = new ListNode(1,
    //         new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4))))));
    //     // Act
    //     var result = LeetEasy.MergeTwoLists(list1, list2);
    //     
    //     // Assert
    //     result.Should().BeEquivalentTo(expected);
    // }

    [Fact]
    public void RemoveDuplicated()
    {
        // Arrange
        int[] input = [1, 1, 2];
        const int expected = 2;

        // Act
        var result = LeetEasy.RemoveDuplicated(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void RemoveElement()
    {
        // Arrange
        int[] input = [3, 2, 2, 3];
        const int target = 3;
        const int expected = 2;

        // Act
        var result = LeetEasy.RemoveElement(input, target);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void StrStr()
    {
        // Arrange
        const string haystack = "sadbutsad";
        const string needle = "sad";
        const int expected = 0;

        // Act
        var result = LeetEasy.StrStr(haystack, needle);
        var result2 = LeetEasy.StrStr2(haystack, needle);

        // Assert
        using var _ = new AssertionScope();
        result.Should().Be(expected);
        result2.Should().Be(expected);
    }

    [Fact]
    public void SearchInsert()
    {
        // Arrange
        int[] input = [1, 3, 5, 6];
        const int target = 2;
        const int expected = 1;

        // Act
        var result = LeetEasy.SearchInsert(input, target);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void LengthOfLastWord()
    {
        // Arrange
        const string input = "luffy is still joyboy";
        const int expected = 6;

        // Act
        var result = LeetEasy.LengthOfLastWord(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void PlusOne()
    {
        // Arrange
        int[] input = [9, 9];
        int[] expected = [1, 0, 0];

        // Act
        var result = LeetEasy.PlusOne(input);

        // Assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void AddBinary()
    {
        // Arrange
        const string input1 = "1010";
        const string input2 = "1011";
        const string expected = "10101";

        // Act
        var result = LeetEasy.AddBinary(input1, input2);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void MySqrt()
    {
        // Arrange
        const int input = 8;
        const int expected = 2;

        // Act
        var result = LeetEasy.MySqrt(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ClimbStairs()
    {
        // Arrange
        const int input = 3;
        const int expected = 3;

        // Act
        var result = LeetEasy.ClimbStairs(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void MergeSortedArray()
    {
        // Arrange
        var input1 = new[] { 1, 2, 3, 0, 0, 0 };
        const int m = 3;
        var input2 = new[] { 2, 5, 6 };
        const int n = 3;
        var expected = new[] { 1, 2, 2, 3, 5, 6 };

        // Act
        LeetEasy.MergeSortedArray(input1, m, input2, n);

        // Assert
        input1.Should().Equal(expected)
            .And.BeInAscendingOrder();
    }

    [Fact]
    public void PascalsTriangle()
    {
        // Arrange
        const int input = 5;
        IList<IList<int>> expected = [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]];

        // Act
        var result = LeetEasy.PascalsTriangle(input);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void PascalsTriangleRow()
    {
        // Arrange
        const int input = 3;
        IList<int> expected = [1, 3, 3, 1];

        // Act
        var result = LeetEasy.PascalsTriangleRow(input);

        // Assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void PascalsTriangleRow2()
    {
        // Arrange
        const int input = 3;
        IList<int> expected = [1, 3, 3, 1];

        // Act
        var result = LeetEasy.PascalsTriangleRow2(input);

        // Assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void BestTimeToBuyAndSellStock()
    {
        // Arrange
        int[] input = [7, 1, 5, 3, 6, 4];
        const int expected = 5;

        // Act
        var result = LeetEasy.BestTimeToBuyAndSellStock(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsValidPalindrome()
    {
        // Arrange
        const string input = "A man, a plan, a canal: Panama";

        // Act
        var result = LeetEasy.IsValidPalindrome(input);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void SingleNumber()
    {
        // Arrange
        var input = new[] { 2, 2, 1 };
        const int expected = 1;

        // Act
        var result1 = LeetEasy.SingleNumber(input);
        var result2 = LeetEasy.SingleNumber2(input);

        // Assert
        using var _ = new AssertionScope();
        result1.Should().Be(expected);
        result2.Should().Be(expected);
    }

    [Fact]
    public void ExcelConvertToTitle()
    {
        // Arrange
        const int columnNumber = 28;
        const string expected = "AB";

        // Act
        var result = LeetEasy.ExcelConvertToTitle(columnNumber);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void MajorityElement()
    {
        // Arrange
        var input = new[] { 3, 2, 3 };
        const int expected = 3;

        // Act
        var result = LeetEasy.MajorityElement(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ExcelConvertToTitleNumber()
    {
        // Arrange
        const string input = "ZY";
        const int expected = 701;

        // Act
        var result = LeetEasy.ExcelConvertToTitleNumber(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsHappy()
    {
        // Arrange
        const int input1 = 19;
        const int input2 = 2;
        // Act
        var result1 = LeetEasy.IsHappy(input1);
        var result2 = LeetEasy.IsHappy(input2);
        var result3 = LeetEasy.IsHappy2(input1);
        var result4 = LeetEasy.IsHappy2(input2);

        // Assert
        using var _ = new AssertionScope();
        result1.Should().BeTrue();
        result2.Should().BeFalse();
        result3.Should().BeTrue();
        result4.Should().BeFalse();
    }

    [Fact]
    public void IsIsomorphic()
    {
        // Arrange
        const string input1 = "egg";
        const string input2 = "add";

        // Act
        var result = LeetEasy.IsIsomorphic(input1, input2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ContainsDuplicate()
    {
        // Arrange
        int[] input = [1, 1, 1, 3, 3, 4, 3, 2, 4, 2];

        // Act
        var result = LeetEasy.ContainsDuplicate(input);

        // Assert
        result.Should().BeTrue();
    }    
    
    [Fact]
    public void ContainsNearbyDuplicate()
    {
        // Arrange
        int[] input1 = [1, 2, 3, 1, 2, 3];
        const int input2 = 2;

        // Act
        var result = LeetEasy.ContainsNearbyDuplicate(input1, input2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void SummaryRanges()
    {
        // Arrange
        int[] input = [0, 2, 3, 4, 6, 8, 9];
        string[] expected = ["0", "2->4", "6", "8->9"];
        
        // Act
        var result = LeetEasy.SummaryRanges(input);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void IsAnagram()
    {
        // Arrange
        const string input1 = "anagram";
        const string input2 = "nagaram";
        
        // Act
        var result = LeetEasy.IsAnagram(input1, input2);

        // Assert
        result.Should().BeTrue();
    }
    
    [Fact]
    public void AddDigits()
    {
        // Arrange
        const int input = 38;
        const int expected = 2;
        
        // Act
        var result = LeetEasy.AddDigits(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Fact]
    public void CanConstruct()
    {
        // Arrange
        const string input1 = "aa";
        const string input2 = "aab";

        // Act
        var result = LeetEasy.CanConstruct(input1, input2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void FizzBuzz()
    {
        // Arrange
        const int input = 5;
        string[] expected = ["1", "2", "Fizz", "4", "Buzz"];

        // Act
        var result = LeetEasy.FizzBuzz(input);

        // Assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void NumberOfSteps()
    {
        // Arrange
        const int input = 14;
        const int expected = 6;

        // Act
        var result = LeetEasy.NumberOfSteps(input);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void KWeakestRows()
    {
        // Arrange
        int[][] input1 =
        [
            [1, 1, 0, 0, 0],
            [1, 1, 1, 1, 0],
            [1, 0, 0, 0, 0],
            [1, 1, 0, 0, 0],
            [1, 1, 1, 1, 1]
        ];
        const int input2 = 3;
        int[] expected = [2, 0, 3];

        // Act
        var result = LeetEasy.KWeakestRows(input1, input2);

        // Assert
        result.Should().Equal(expected);
    }
}