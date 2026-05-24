using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public class GroupAddressee : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addresses;

    public GroupAddressee(IReadOnlyCollection<IAddressee> addresses)
    {
        _addresses = addresses;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee addressee in _addresses)
        {
            addressee.SendMessage(message);
        }
    }
}