namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public record CommandResult
{
    private CommandResult() { }

    public sealed record Success : CommandResult;

    public sealed record Fail(string Message) : CommandResult;
}