namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File;

public class FileLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public FileLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "file")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}