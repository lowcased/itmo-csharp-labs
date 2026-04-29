namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;

public abstract class ParserLinkBase : IParserLink
{
    private IParserLink? _next;

    public IParserLink AddNext(IParserLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    public abstract ParseResult Apply(ArgsIterator iterator);

    protected ParseResult CallNext(ArgsIterator iterator)
    {
        if (_next is null)
        {
            return new ParseResult.Fail();
        }

        return _next.Apply(iterator);
    }
}