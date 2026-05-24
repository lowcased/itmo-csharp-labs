using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages = new();

    public IReadOnlyList<Message> Messages => _messages;

    public void SaveMessage(Message message)
    {
        _messages.Add(message);
    }
}