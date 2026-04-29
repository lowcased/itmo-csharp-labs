using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Connect;

public class AddressLink : ParserLinkBase
{
    private readonly ConnectBuilder _builder;

    public AddressLink(ConnectBuilder commandBuilder)
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
        var address = new FilePath(argument);
        _builder.AddAddress(address);
        return CallNext(iterator);
    }
}