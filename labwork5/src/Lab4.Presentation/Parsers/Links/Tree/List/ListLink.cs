namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Tree.List;

public class ListLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public ListLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "list")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}