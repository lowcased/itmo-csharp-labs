using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public record ParseResult
{
    private ParseResult() { }

    public sealed record Success(ICommand Command) : ParseResult;

    public sealed record Fail : ParseResult;
}