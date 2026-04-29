using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Segments;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TrainTests
{
    [Fact]
    public void ForceApply_ShouldFail_When_MaxForceExceeded()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(100);
        var accuracy = new Accuracy(2);
        var distance = new Distance(100);
        double force = 200;
        var train = new Train(mass, maxForce, accuracy);
        var forceApplicator = new ForceSegment(distance, force);

        // Act
        bool result = train.ApplyForce(forceApplicator);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ForceApply_ShouldPassSuccess_When_MaxForceNotExceeded()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(300);
        var accuracy = new Accuracy(2);
        var distance = new Distance(100);
        double force = 200;
        var train = new Train(mass, maxForce, accuracy);
        var forceApplicator = new ForceSegment(distance, force);

        // Act
        bool result = train.ApplyForce(forceApplicator);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CalculateTime_ShouldFail_When_NoForceApplied()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(300);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var distance = new Distance(100);

        // Act
        TimeResult result = train.CalculateTime(distance);

        // Assert
        Assert.IsType<TimeResult.Fail>(result);
    }

    [Fact]
    public void CalculateTime_ShouldPass_When_ForceApplied()
    {
        // Arrange
        var mass = new Mass(5);
        var maxForce = new MaxForce(300);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var distance = new Distance(10);
        var forceApplicator = new ForceSegment(distance, 5);

        // Act
        train.ApplyForce(forceApplicator);
        TimeResult result = train.CalculateTime(distance);

        // Assert
        TimeResult.Success success = Assert.IsType<TimeResult.Success>(result);
        Assert.Equal(4, success.Time);
    }

    [Fact]
    public void CalculateTime_ShouldFail_When_ForceIsNegative()
    {
        // Arrange
        var mass = new Mass(5);
        var maxForce = new MaxForce(300);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var distance = new Distance(10);
        var forceApplicator = new ForceSegment(distance, -5);

        // Act
        bool applied = train.ApplyForce(forceApplicator);
        TimeResult result = train.CalculateTime(distance);

        // Assert
        Assert.True(applied);
        TimeResult.Fail fail = Assert.IsType<TimeResult.Fail>(result);
    }

    [Fact]
    public void TrainConstructor_ShouldFail_When_MassIsNegative()
    {
        // Arrange
        const double invalidMass = -10;
        var maxForce = new MaxForce(100);
        var accuracy = new Accuracy(1);

        // Act
        Action act = () => _ = new Train(new Mass(invalidMass), maxForce, accuracy);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void TrainConstructor_ShouldFail_When_AccuracyIsNegative()
    {
        // Arrange
        var mass = new Mass(10);
        var maxForce = new MaxForce(100);
        const double invalidAccuracy = -10;

        // Act
        Action act = () => _ = new Train(mass, maxForce, new Accuracy(invalidAccuracy));

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void TrainConstructor_ShouldFail_When_MaxForceIsNegative()
    {
        // Arrange
        var mass = new Mass(10);
        const double invalidMaxForce = -100;
        var accuracy = new Accuracy(10);

        // Act
        Action act = () => _ = new Train(mass, new MaxForce(invalidMaxForce), accuracy);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}