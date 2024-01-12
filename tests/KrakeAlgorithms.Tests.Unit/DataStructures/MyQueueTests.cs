using FluentAssertions.Execution;
using KrakeAlgorithms.Lib.DataStructures;

namespace KrakeAlgorithms.Tests.Unit.DataStructures;

public sealed class MyQueueTests
{
    [Fact]
    public void Enqueue_ShouldEnqueueOneItem_WhenQueueIsEmpty()
    {
        // Arrange
        var sut = new MyQueue<Item>();

        // Act
        sut.Enqueue(new Item());
        var result = sut.Length;

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void Enqueue_ShouldEnqueueOneItems_WhenQueueStartsWithOneItem()
    {
        // Arrange
        var sut = new MyQueue<Item>();
        sut.Enqueue(new Item());

        // Act
        sut.Enqueue(new Item());
        var result = sut.Length;

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void Dequeue_ShouldDequeueOneItem_WhenQueueStartsWithThreeItems()
    {
        // Arrange
        var sut = new MyQueue<Item>();
        sut.Enqueue(new Item(0));
        sut.Enqueue(new Item(1));
        sut.Enqueue(new Item(2));

        // Act
        var result = sut.Dequeue();

        // Assert
        using var scope = new AssertionScope();
        result.Should().Be(new Item(0));
        sut.Length.Should().Be(2);
    }

    [Fact]
    public void Dequeue_ShouldPushNextItemForward_WhenEnqueuePreviouslyDequeuedItem()
    {
        // Arrange
        var sut = new MyQueue<Item>();
        sut.Enqueue(new Item(0));
        sut.Enqueue(new Item(1));

        // Act
        var item = sut.Dequeue();
        sut.Enqueue(item);
        var result = sut.Peek();

        // Assert
        using var scope = new AssertionScope();
        result.Should().Be(new Item(1));
        sut.Length.Should().Be(2);
    }

    [Fact]
    public void Peek_ShouldReturnFirstItemInQueue_WhenQueueStartsWithTwoItems()
    {
        // Arrange
        var sut = new MyQueue<Item>();
        sut.Enqueue(new Item(0));
        sut.Enqueue(new Item(1));

        // Act
        var result = sut.Peek();

        // Assert
        using var scope = new AssertionScope();
        result.Should().Be(new Item(0));
        sut.Length.Should().Be(2);
    }


    private readonly record struct Item(int Value);
}