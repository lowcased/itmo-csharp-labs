using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Tree.List;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class TreeListFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new TreeListBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        argumentBuilder.AddFlag(new DepthLink(commandBuilder));
        IParserLink link = argumentBuilder.Build();
        return new ListLink(link);
    }
}