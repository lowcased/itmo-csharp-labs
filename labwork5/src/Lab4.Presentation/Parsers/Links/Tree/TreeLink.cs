namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Tree;

public class TreeLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public TreeLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "tree")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}