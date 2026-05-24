using Itmo.ObjectOrientedProgramming.Lab2.Addressee;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IAddressee
{
    private readonly HashSet<Message> _readMessages = new();
    private readonly HashSet<Message> _messages = new();

    public void SendMessage(Message message)
    {
        _messages.Add(message);
    }

    public MarkAsReadResult MarkAsRead(Message message)
    {
        if (!_messages.Contains(message))
        {
            return new MarkAsReadResult.NotFound();
        }

        if (!_readMessages.Add(message))
        {
            return new MarkAsReadResult.AlreadyRead();
        }

        return new MarkAsReadResult.Success();
    }

    public bool IsMessageRead(Message message)
    {
        return _readMessages.Contains(message);
    }
}