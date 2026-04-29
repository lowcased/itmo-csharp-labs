using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class CommandLinkFactory
{
    public IParserLink Create()
    {
        IParserLink connectLink = new ConnectFactory().Create();
        IParserLink disconnectLink = new DisconnectFactory().Create();
        IParserLink treeLink = new TreeFactory().Create();
        IParserLink fileLink = new FileFactory().Create();

        connectLink.AddNext(disconnectLink)
                   .AddNext(treeLink)
                   .AddNext(fileLink);
        return connectLink;
    }
}