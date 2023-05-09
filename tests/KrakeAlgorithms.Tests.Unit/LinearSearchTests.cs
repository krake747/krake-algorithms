using KrakeAlgorithms.Lib;

namespace KrakeAlgorithms.Tests.Unit;

public class LinearSearchTests
{
    [Theory]
    [ClassData(typeof(LinearSearchData))]
    public void LinearSearch_ShouldReturnTrue_WhenNeedleIsFound(int[] sample, int element, bool expected)
    {
        // Arrange
        var sut = SearchAlgorithms.LinearSearch<int>;

        // Act
        var result = sut(sample, element);

        // Assert
        result.Should().Be(expected);
    }
}

public class LinearSearchData : TheoryData<int[], int, bool>
{
    private readonly int[] _sample = new[] { 1, 2, 31, 47, 49, 62, 70, 100 };

    public LinearSearchData()
    {
        Add(_sample, 1, true);
        Add(_sample, 3, false);
        Add(_sample, 99, false);
        Add(_sample, 100, true);
    }
}