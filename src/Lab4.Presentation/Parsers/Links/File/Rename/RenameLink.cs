namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Rename;

public class RenameLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public RenameLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "rename")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}