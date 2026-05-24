using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class Parser : IParser
{
    private readonly IParserLink _link;

    public Parser(IParserLink link)
    {
        _link = link;
    }

    public ParseResult Parse(string[] args)
    {
        var iterator = new ArgsIterator(args);
        return _link.Apply(iterator);
    }
}