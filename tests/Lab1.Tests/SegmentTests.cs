using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Segments;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SegmentTests
{
    [Fact]
    public void Pass_ShouldFail_When_OnlyDefaultSegment()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(1000);
        var accuracy = new Accuracy(100);
        var distance = new Distance(100);
        var train = new Train(mass, maxForce, accuracy);
        var defaultSegment = new DefaultSegment(distance);

        // Act
        SegmentResult result = defaultSegment.Pass(train);

        // Assert
        Assert.IsType<SegmentResult.Fail>(result);
    }

    [Fact]
    public void DistanceConstructor_ShouldFail_When_ValueIsNegative()
    {
        // Arrange
        const double invalidValue = -100;

        // Act
        Action act = () => _ = new Distance(invalidValue);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void Pass_ShouldFail_When_ForceIsNegative()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(100);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var distance = new Distance(100);
        double force = -100;
        var forceSegment = new ForceSegment(distance, force);

        // Act
        SegmentResult result = forceSegment.Pass(train);

        // Assert
        Assert.IsType<SegmentResult.Fail>(result);
    }

    [Fact]
    public void StationConstructor_ShouldFail_When_BoardingTimeIsNegative()
    {
        // Arrange
        const int invalidBoardingTime = -100;
        const int velocityLimit = 100;

        // Act
        Action act = () => _ = new Station(invalidBoardingTime, velocityLimit);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}