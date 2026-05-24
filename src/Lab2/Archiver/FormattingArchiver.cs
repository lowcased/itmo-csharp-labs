using Itmo.ObjectOrientedProgramming.Lab2.Formatter;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver;

public class FormattingArchiver : IArchiver
{
    private readonly IMessageFormatter _messageFormatter;

    public FormattingArchiver(IMessageFormatter messageFormatter)
    {
        _messageFormatter = messageFormatter;
    }

    public void SaveMessage(Message message)
    {
        _messageFormatter.WriteHeader(message.Header);
        _messageFormatter.WriteBody(message.Body);
    }
}