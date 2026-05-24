using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Factories;

public class FileFactory : ILinkFactory
{
    public IParserLink Create()
    {
        IParserLink showLink = new FileShowFactory().Create();
        IParserLink moveLink = new FileMoveFactory().Create();
        IParserLink copyLink = new FileCopyFactory().Create();
        IParserLink deleteLink = new FileDeleteFactory().Create();
        IParserLink renameLink = new FileRenameFactory().Create();

        showLink.AddNext(moveLink)
                .AddNext(copyLink)
                .AddNext(deleteLink)
                .AddNext(renameLink);
        return new FileLink(showLink);
    }
}