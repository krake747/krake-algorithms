using KrakeAlgorithms.LeetCode;

namespace KrakeAlgorithms.Tests.Unit.LeetCode;

public sealed class LeetEasyTests
{
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
}