namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Tree.Gotos;

public class GotoLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public GotoLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "goto")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}