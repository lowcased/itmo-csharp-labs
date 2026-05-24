using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Move;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class FileMoveFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new FileMoveBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        argumentBuilder.AddPositional(new SourcePathLink(commandBuilder)).AddPositional(new DestinationPathLink(commandBuilder));
        IParserLink link = argumentBuilder.Build();
        return new MoveLink(link);
    }
}