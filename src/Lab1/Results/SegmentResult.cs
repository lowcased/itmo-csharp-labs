namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public record SegmentResult
{
    private SegmentResult() { }

    public sealed record class Success(double Time) : SegmentResult;

    public sealed record class Fail : SegmentResult;
}