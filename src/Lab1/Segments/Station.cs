using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Segments;

public class Station : ISegment
{
    private readonly double _boardingTime;
    private readonly double _velocityLimit;

    public Station(double boardingTime, double velocityLimit)
    {
        if (boardingTime < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(boardingTime), "Boarding time cannot be negative");
        }

        _boardingTime = boardingTime;
        _velocityLimit = velocityLimit;
    }

    public SegmentResult Pass(Train train)
    {
        double velocity = train.Velocity;
        if (velocity > _velocityLimit)
        {
            return new SegmentResult.Fail();
        }

        return new SegmentResult.Success(_boardingTime);
    }
}