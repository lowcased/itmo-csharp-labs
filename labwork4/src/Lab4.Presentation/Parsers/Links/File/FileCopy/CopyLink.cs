namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.FileCopy;

public class CopyLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public CopyLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "copy")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}