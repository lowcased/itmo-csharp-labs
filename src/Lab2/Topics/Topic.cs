using Itmo.ObjectOrientedProgramming.Lab2.Addressee;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    public string Name { get; }

    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public Topic(string name, IReadOnlyCollection<IAddressee> addresses)
    {
        Name = name;
        _addressees = addresses;
    }

    public void SendMessage(Message message, IAddressee addressee)
    {
        if (_addressees.Contains(addressee))
        {
            addressee.SendMessage(message);
        }
    }
}