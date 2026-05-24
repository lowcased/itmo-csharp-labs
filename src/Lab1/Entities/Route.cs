using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Segments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Route
{
    private readonly double _velocityLimit;
    private readonly IReadOnlyCollection<ISegment> _segments;

    public Route(IReadOnlyCollection<ISegment> segments, double velocityLimit)
    {
        _segments = segments;
        _velocityLimit = velocityLimit;
    }

    public RouteResult PassSegments(Train train)
    {
        double sumTime = 0;
        foreach (ISegment segment in _segments)
        {
            SegmentResult segmentResult = segment.Pass(train);
            if (segmentResult is SegmentResult.Fail)
            {
                return new RouteResult.Fail();
            }

            if (segmentResult is SegmentResult.Success success)
            {
                sumTime += success.Time;
            }
        }

        if (train.Velocity > _velocityLimit)
        {
            return new RouteResult.Fail();
        }

        return new RouteResult.Success(sumTime);
    }
}