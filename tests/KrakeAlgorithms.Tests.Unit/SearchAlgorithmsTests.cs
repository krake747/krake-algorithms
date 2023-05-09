using KrakeAlgorithms.Lib;

namespace KrakeAlgorithms.Tests.Unit;

public class SearchAlgorithmsTests
{
    [Theory]
    [ClassData(typeof(SortedData))]
    public void LinearSearch_ShouldReturnExpected_WhenNeedleIsFoundOrNotFound(int[] sample, int element, bool expected)
    {
        // Arrange
        var sut = SearchAlgorithms.LinearSearch<int>;

        // Act
        var result = sut(sample, element);

        // Assert
        result.Should().Be(expected);
    }
}

public class SortedData : TheoryData<int[], int, bool>
{
    private readonly int[] _sorted = { 1, 2, 13, 31, 47, 49, 62, 69, 70, 100 };

    public SortedData()
    {
        Add(_sorted, 1, true);
        Add(_sorted, 3, false);
        Add(_sorted, 99, false);
        Add(_sorted, 100, true);
    }
}