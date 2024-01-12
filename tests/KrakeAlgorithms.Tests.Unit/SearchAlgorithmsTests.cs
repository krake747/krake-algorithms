using KrakeAlgorithms;

namespace KrakeAlgorithms.Tests.Unit;

public sealed class SearchAlgorithmsTests
{
    [Theory]
    [ClassData(typeof(SortedData))]
    public void LinearSearch_ShouldReturnExpectedIndex_WhenNeedleIsFoundOrNotFound(int[] sample, int element,
        int expected)
    {
        // Arrange
        var sut = SearchAlgorithms.LinearSearch<int>;

        // Act
        var result = sut(sample, element);

        // Assert
        result.Should().Be(expected);
    }


    [Theory]
    [ClassData(typeof(SortedData))]
    public void BinarySearch_ShouldReturnExpectedIndex_WhenNeedleIsFoundOrNotFound(int[] sample, int element,
        int expected)
    {
        // Arrange
        var sut = SearchAlgorithms.BinarySearch<int>;

        // Act
        var result = sut(sample, element);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(SortedBooleanData))]
    public void TwoGlassBallsSearch_ShouldReturnExpectedIndex_WhenGlassBallBreakOrNotBreaks(bool[] sample, int expected)
    {
        // Arrange
        var sut = SearchAlgorithms.TwoGlassBallsSearch;

        // Act
        var result = sut(sample);

        // Assert
        result.Should().Be(expected);
    }
}

public sealed class SortedData : TheoryData<int[], int, int>
{
    private readonly int[] _sorted = [1, 2, 13, 31, 47, 49, 62, 69, 70, 100];

    public SortedData()
    {
        Add(_sorted, 1, 0);
        Add(_sorted, 3, -1);
        Add(_sorted, 62, 6);
        Add(_sorted, 99, -1);
    }
}

public sealed class SortedBooleanData : TheoryData<bool[], int>
{
    private readonly bool[] _empty = new bool[100];
    private readonly bool[] _sorted = new bool[100];

    public SortedBooleanData()
    {
        var index = (int)Math.Sqrt(Random.Shared.Next(0, 100));
        for (var i = index; i < _sorted.Length; ++i)
        {
            _sorted[i] = true;
        }

        Add(_sorted, index);
        Add(_empty, -1);
    }
}