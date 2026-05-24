namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Show;

public class ShowLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public ShowLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "show")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}