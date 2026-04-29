using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public record CommandBuilderResult
{
    private CommandBuilderResult() { }

    public sealed record Success(ICommand Command) : CommandBuilderResult;

    public sealed record Fail : CommandBuilderResult;
}