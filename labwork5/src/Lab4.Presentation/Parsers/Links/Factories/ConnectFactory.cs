using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Connect;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class ConnectFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new ConnectBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        argumentBuilder.AddPositional(new AddressLink(commandBuilder)).AddFlag(new ModeLink(commandBuilder));
        IParserLink link = argumentBuilder.Build();
        return new ConnectLink(link);
    }
}