using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;

public class TerminalArgLink : ParserLinkBase
{
    private readonly ICommandBuilder _builder;

    public TerminalArgLink(ICommandBuilder builder)
    {
        _builder = builder;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        if (iterator.Peek() != null)
        {
            return new ParseResult.Fail();
        }

        CommandBuilderResult result = _builder.Build();
        if (result is CommandBuilderResult.Success success)
        {
            return new ParseResult.Success(success.Command);
        }

        return new ParseResult.Fail();
    }
}