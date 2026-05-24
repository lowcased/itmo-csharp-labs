namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Delete;

public class DeleteLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public DeleteLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "delete")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}