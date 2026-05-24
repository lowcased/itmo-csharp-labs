namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public record TimeResult
{
    private TimeResult() { }

    public sealed record class Success(double Time) : TimeResult;

    public sealed record class Fail : TimeResult;
}