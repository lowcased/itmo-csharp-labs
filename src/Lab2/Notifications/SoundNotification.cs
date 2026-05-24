namespace Itmo.ObjectOrientedProgramming.Lab2.Notifications;

public class SoundNotification : INotification
{
    public void SendNotification()
    {
        Console.Beep();
    }
}