using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Segments;

public class DefaultSegment : ISegment
{
    private readonly Distance _distance;

    public DefaultSegment(Distance distance)
    {
        _distance = distance;
    }

    public SegmentResult Pass(Train train)
    {
        TimeResult timeResult = train.CalculateTime(_distance);
        if (timeResult is TimeResult.Success(var time))
        {
            return new SegmentResult.Success(time);
        }

        return new SegmentResult.Fail();
    }
}