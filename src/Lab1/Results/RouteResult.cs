namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public record RouteResult
{
    private RouteResult() { }

    public sealed record class Success(double Time) : RouteResult;

    public sealed record class Fail : RouteResult;
}