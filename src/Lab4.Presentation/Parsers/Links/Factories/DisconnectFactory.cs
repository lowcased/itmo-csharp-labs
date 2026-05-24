using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Disconnect;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class DisconnectFactory : ILinkFactory
{
    public IParserLink Create()
    {
        var commandBuilder = new DisconnectBuilder();
        var argumentBuilder = new ArgumentBuilder(commandBuilder);
        IParserLink link = argumentBuilder.Build();
        return new DisconnectLink(link);
    }
}