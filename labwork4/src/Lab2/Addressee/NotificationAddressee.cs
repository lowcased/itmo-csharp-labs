using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Notifications;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public class NotificationAddressee : IAddressee
{
    private readonly INotification _notification;

    private readonly IReadOnlyCollection<string> _words;

    public NotificationAddressee(INotification notification, IReadOnlyCollection<string> words)
    {
        _notification = notification;
        _words = words;
    }

    public void SendMessage(Message message)
    {
        foreach (string word in _words)
        {
            bool foundInHeader = message.Header.Contains(word, StringComparison.OrdinalIgnoreCase);
            bool foundInBody = message.Body.Contains(word, StringComparison.OrdinalIgnoreCase);
            if (foundInHeader || foundInBody)
            {
                _notification.SendNotification();
            }
        }
    }
}