using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Connect;

public class ModeLink : FlagLinkBase
{
    private readonly ConnectBuilder _builder;

    public ModeLink(ConnectBuilder commandBuilder)
    {
        _builder = commandBuilder;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? argument = iterator.Peek();
        if (argument == "-m")
        {
            iterator.Next();
            argument = iterator.Peek();
            if (argument == null)
            {
                argument = "local";
            }

            if (argument == "local")
            {
                _builder.AddFilesystem(new LocalFileSystemFactory());
            }
            else
            {
                return new ParseResult.Fail();
            }

            iterator.Next();
            return First.Apply(iterator);
        }

        return CallNext(iterator);
    }
}