using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Delete;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class FileDeleteFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new FileDeleteBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        argumentBuilder.AddPositional(new PathLink(commandBuilder));
        IParserLink link = argumentBuilder.Build();
        return new DeleteLink(link);
    }
}