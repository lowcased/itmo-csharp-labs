using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class TreeFactory : ILinkFactory
{
    public IParserLink Create()
    {
        IParserLink gotoLink = new TreeGotoFactory().Create();
        IParserLink listLink = new TreeListFactory().Create();

        gotoLink.AddNext(listLink);
        return new TreeLink(gotoLink);
    }
}