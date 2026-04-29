namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Connect;

public class ConnectLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public ConnectLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "connect")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}