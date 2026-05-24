using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Show;

public class ModeLink : FlagLinkBase
{
    private readonly FileShowBuilder _builder;

    public ModeLink(FileShowBuilder commandBuilder)
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
            if (argument == "console")
            {
                _builder.AddPrinter(new ConsoleFilePrinter());
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