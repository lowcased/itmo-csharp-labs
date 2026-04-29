using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.FileCopy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class FileCopyFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new FileCopyBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        argumentBuilder.AddPositional(new SourcePathLink(commandBuilder)).AddPositional(new DestinationPathLink(commandBuilder));
        IParserLink link = argumentBuilder.Build();
        return new CopyLink(link);
    }
}