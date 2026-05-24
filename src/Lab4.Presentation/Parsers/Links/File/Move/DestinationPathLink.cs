using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Move;

public class DestinationPathLink : ParserLinkBase
{
    private readonly FileMoveBuilder _builder;

    public DestinationPathLink(FileMoveBuilder commandBuilder)
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
        var path = new FilePath(argument);
        _builder.AddDestinationPath(path);
        return CallNext(iterator);
    }
}