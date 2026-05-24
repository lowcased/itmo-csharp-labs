using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Tree.Gotos;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class TreeGotoFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new TreeGotoBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        argumentBuilder.AddPositional(new PathLink(commandBuilder));
        IParserLink link = argumentBuilder.Build();
        return new GotoLink(link);
    }
}