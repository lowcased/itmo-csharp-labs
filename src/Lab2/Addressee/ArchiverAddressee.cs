using Itmo.ObjectOrientedProgramming.Lab2.Archiver;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public class ArchiverAddressee : IAddressee
{
    private readonly IArchiver _archiver;

    public ArchiverAddressee(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public void SendMessage(Message message)
    {
        _archiver.SaveMessage(message);
    }
}