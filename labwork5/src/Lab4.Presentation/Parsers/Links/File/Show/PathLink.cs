using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Show;

public class PathLink : ParserLinkBase
{
    private readonly FileShowBuilder _builder;

    public PathLink(FileShowBuilder commandBuilder)
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
        _builder.AddPath(path);
        return CallNext(iterator);
    }
}