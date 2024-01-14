﻿using KrakeAlgorithms.LeetCode;

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
        int[] input = [3,2,2,3];
        const int target = 3;
        const int expected = 2;
        
        // Act
        var result = LeetEasy.RemoveElement(input, target);

        // Assert
        result.Should().Be(expected);
    }
}