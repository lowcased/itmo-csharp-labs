using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Rename;

public class NameLink : ParserLinkBase
{
    private readonly FileRenameBuilder _builder;

    public NameLink(FileRenameBuilder commandBuilder)
    {
        _builder = commandBuilder;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? argument = iterator.Peek();
        if (argument == null)
        {
            return new ParseResult.Fail();
        }

        iterator.Next();
        _builder.AddName(argument);
        return CallNext(iterator);
    }
}