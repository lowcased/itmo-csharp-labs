namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Move;

public class MoveLink : ParserLinkBase
{
    private readonly IParserLink _link;

    public MoveLink(IParserLink link)
    {
        _link = link;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? command = iterator.Peek();
        if (command != "move")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        return _link.Apply(iterator);
    }
}