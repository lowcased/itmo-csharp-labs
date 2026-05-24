namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;

public interface IParserLink
{
    IParserLink AddNext(IParserLink link);

    ParseResult Apply(ArgsIterator iterator);
}