using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.FileCopy;

public class SourcePathLink : ParserLinkBase
{
    private readonly FileCopyBuilder _builder;

    public SourcePathLink(FileCopyBuilder commandBuilder)
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
        _builder.AddSourcePath(path);
        return CallNext(iterator);
    }
}