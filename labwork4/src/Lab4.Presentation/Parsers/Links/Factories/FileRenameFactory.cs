using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File.Rename;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class FileRenameFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new FileRenameBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        argumentBuilder.AddPositional(new PathLink(commandBuilder)).AddPositional(new NameLink(commandBuilder));
        IParserLink link = argumentBuilder.Build();
        return new RenameLink(link);
    }
}