namespace KrakeAlgorithms.Tests.Unit;

public sealed class SortAlgorithmsTests
{
    [Theory]
    [ClassData(typeof(UnsortedData))]
    public void BubbleSort_ShouldReturnSortedArray_WhenInputArrayIsUnsorted(int[] unsorted, int[] expected)
    {
        // Arrange
        var sut = SortAlgorithms.BubbleSort<int>;

        // Act
        var result = sut(unsorted);

        // Assert
        result.Should().Equal(expected)
            .And.BeInAscendingOrder();
    }
}

public sealed class UnsortedData : TheoryData<int[], int[]>
{
    private readonly int[] _sorted = [1, 2, 13, 31, 47, 49, 62, 69, 70, 100];
    private readonly int[] _unsorted = [69, 100, 47, 70, 13, 49, 62, 1, 31, 2];

    public UnsortedData()
    {
        Add(_unsorted, _sorted);
    }
}