using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Segments;

public class ForceSegment : ISegment, IForceApplicator
{
    public double Force { get; }

    private readonly Distance _distance;

    public ForceSegment(Distance distance, double force)
    {
        _distance = distance;
        Force = force;
    }

    public SegmentResult Pass(Train train)
    {
        if (!train.ApplyForce(this))
        {
            return new SegmentResult.Fail();
        }

        TimeResult timeResult = train.CalculateTime(_distance);
        train.ResetForce(this);
        return timeResult is TimeResult.Success(var time) ?
            new SegmentResult.Success(time) : new SegmentResult.Fail();
    }
}