namespace Itmo.ObjectOrientedProgramming.Lab2.Notifications;

public class TextNotification : INotification
{
    private readonly string _text;

    public TextNotification(string text)
    {
        _text = text;
    }

    public void SendNotification()
    {
        Console.WriteLine(_text);
    }
}