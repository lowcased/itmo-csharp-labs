namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Disconnect;

public class DisconnectLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public DisconnectLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "disconnect")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}