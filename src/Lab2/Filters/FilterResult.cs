using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Filters;

public record FilterResult
{
    private FilterResult() { }

    public sealed record Passed(Message Message) : FilterResult;

    public sealed record Failed : FilterResult;
}