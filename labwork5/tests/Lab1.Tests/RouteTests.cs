using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Segments;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void PassSegments_ShouldPassSuccess_When_OnlyForceSegment()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment1 = new ForceSegment(new Distance(1000), 1000);
        var forceSegment2 = new ForceSegment(new Distance(500), 200);
        var forceSegment3 = new ForceSegment(new Distance(3000), 500);
        var segments = new List<ISegment> { forceSegment1, forceSegment2, forceSegment3 };
        var route = new Route(segments, 100);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Success success = Assert.IsType<RouteResult.Success>(result);
        Assert.Equal(108, success.Time);
    }

    [Fact]
    public void PassSegments_ShouldFail_When_OnlyDefaultSegmentAndStation()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var defaultSegment1 = new DefaultSegment(new Distance(1000));
        var station = new Station(500, 100);
        var defaultSegment2 = new DefaultSegment(new Distance(3000));
        var segments = new List<ISegment> { defaultSegment1, station, defaultSegment2 };
        var route = new Route(segments, 100);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Fail fail = Assert.IsType<RouteResult.Fail>(result);
    }

    [Fact]
    public void PassSegment_ShouldPassSuccess_When_DefaultAndForceSegments()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment1 = new ForceSegment(new Distance(1000), 500);
        var defaultSegment1 = new DefaultSegment(new Distance(400));
        var forceSegment2 = new ForceSegment(new Distance(500), -200);
        var segments = new List<ISegment> { forceSegment1, defaultSegment1, forceSegment2 };
        var route = new Route(segments, 100);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Success success = Assert.IsType<RouteResult.Success>(result);
        Assert.Equal(96, success.Time);
    }

    [Fact]
    public void PassSegments_ShouldFail_When_SpeedingOnStation()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment = new ForceSegment(new Distance(1000), 5000);
        var station = new Station(40, 50);
        var segments = new List<ISegment> { forceSegment, station };
        var route = new Route(segments, 100);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Fail fail = Assert.IsType<RouteResult.Fail>(result);
    }

    [Fact]
    public void PassSegments_ShouldFail_When_SpeedingInEnd()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment = new ForceSegment(new Distance(1000), 5000);
        var segments = new List<ISegment> { forceSegment };
        var route = new Route(segments, 10);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Fail fail = Assert.IsType<RouteResult.Fail>(result);
    }

    [Fact]
    public void PassSegments_ShouldPassSuccess_When_DifferentSegmentsUsed()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment1 = new ForceSegment(new Distance(1000), 500);
        var forceSegment2 = new ForceSegment(new Distance(500), 200);
        var forceSegment3 = new ForceSegment(new Distance(200), -400);
        var forceSegment4 = new ForceSegment(new Distance(0), 500);
        var station1 = new Station(10, 500);
        var station2 = new Station(20, 1000);
        var defaultSegment1 = new DefaultSegment(new Distance(400));
        var defaultSegment2 = new DefaultSegment(new Distance(1000));
        var segments = new List<ISegment>
        {
            forceSegment1,
            station1,
            defaultSegment1,
            forceSegment2,
            forceSegment3,
            station2,
            defaultSegment2,
            forceSegment4,
        };
        var route = new Route(segments, 100);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Success success = Assert.IsType<RouteResult.Success>(result);
        Assert.Equal(161, success.Time);
    }

    [Fact]
    public void PassSegments_ShouldPassSuccess_When_RouteMaxVelocityNotExceeded()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment = new ForceSegment(new Distance(1000), 1000);
        var segments = new List<ISegment> { forceSegment };
        var route = new Route(segments, 100);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Success success = Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void PassSegments_ShouldFail_When_RouteMaxVelocityExceeded()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment = new ForceSegment(new Distance(1000), 1000);
        var segments = new List<ISegment> { forceSegment };
        var route = new Route(segments, 10);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Fail fail = Assert.IsType<RouteResult.Fail>(result);
    }

    [Fact]
    public void PassSegments_ShouldPassSuccess_When_StationAndRouteMaxVelocitiesNotExceeded()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment = new ForceSegment(new Distance(1000), 5000);
        var defaultSegment1 = new DefaultSegment(new Distance(500));
        var defaultSegment2 = new DefaultSegment(new Distance(250));
        var station = new Station(20, 100);
        var segments = new List<ISegment> { forceSegment, defaultSegment1, station, defaultSegment2 };
        var route = new Route(segments, 100);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Success success = Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void PassSegments_ShouldFail_When_StationMaxVelocityExceeded()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment = new ForceSegment(new Distance(1000), 8000);
        var defaultSegment = new DefaultSegment(new Distance(500));
        var station = new Station(20, 100);
        var segments = new List<ISegment> { forceSegment, station, defaultSegment };
        var route = new Route(segments, 100);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Fail fail = Assert.IsType<RouteResult.Fail>(result);
    }

    [Fact]
    public void PassSegments_ShouldFail_When_StationMaxVelocityNotExceededButRouteMaxVelocityExceeded()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment = new ForceSegment(new Distance(1000), 5000);
        var defaultSegment1 = new DefaultSegment(new Distance(500));
        var defaultSegment2 = new DefaultSegment(new Distance(250));
        var station = new Station(20, 100);
        var segments = new List<ISegment> { forceSegment, defaultSegment1, station, defaultSegment2 };
        var route = new Route(segments, 50);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Fail fail = Assert.IsType<RouteResult.Fail>(result);
    }

    [Fact]
    public void PassSegments_ShouldPassSuccess_When_TrainSlowedDownToAllowedVelocity()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(5000);
        var accuracy = new Accuracy(1);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment1 = new ForceSegment(new Distance(5000), 5000);
        var forceSegment2 = new ForceSegment(new Distance(6000), -4000);
        var forceSegment3 = new ForceSegment(new Distance(75000), 2000);
        var forceSegment4 = new ForceSegment(new Distance(25000), -3000);
        var defaultSegment1 = new DefaultSegment(new Distance(500));
        var defaultSegment2 = new DefaultSegment(new Distance(250));
        var defaultSegment3 = new DefaultSegment(new Distance(5000));
        var station = new Station(20, 100);
        var segments = new List<ISegment>
        {
            forceSegment1, defaultSegment1, forceSegment2, station,
            defaultSegment2, forceSegment3, defaultSegment3, forceSegment4,
        };
        var route = new Route(segments, 500);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Success success = Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void PassSegments_ShouldFail_When_OnlyOneDefaultSegment()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(100);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var defaultSegment = new DefaultSegment(new Distance(100));
        var segments = new List<ISegment> { defaultSegment };
        var route = new Route(segments, 5000);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Fail fail = Assert.IsType<RouteResult.Fail>(result);
    }

    [Fact]
    public void PassSegments_ShouldFail_When_DecelerationExceedsAcceleration()
    {
        // Arrange
        var mass = new Mass(1000);
        var maxForce = new MaxForce(100);
        var accuracy = new Accuracy(2);
        var train = new Train(mass, maxForce, accuracy);
        var forceSegment1 = new ForceSegment(new Distance(100), 1000);
        var forceSegment2 = new ForceSegment(new Distance(100), -2000);
        var segments = new List<ISegment> { forceSegment1, forceSegment2 };
        var route = new Route(segments, 5000);

        // Act
        RouteResult result = route.PassSegments(train);

        // Assert
        RouteResult.Fail fail = Assert.IsType<RouteResult.Fail>(result);
    }
}