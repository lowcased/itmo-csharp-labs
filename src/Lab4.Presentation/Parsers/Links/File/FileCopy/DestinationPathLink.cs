using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.FileCopy;

public class DestinationPathLink : ParserLinkBase
{
    private readonly FileCopyBuilder _builder;

    public DestinationPathLink(FileCopyBuilder commandBuilder)
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