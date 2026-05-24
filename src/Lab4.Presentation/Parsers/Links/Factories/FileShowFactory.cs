using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Show;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class FileShowFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new FileShowBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        argumentBuilder.AddPositional(new PathLink(commandBuilder)).AddFlag(new ModeLink(commandBuilder));
        IParserLink link = argumentBuilder.Build();
        return new ShowLink(link);
    }
}