namespace Itmo.ObjectOrientedProgramming.Lab4.Core.OutputManager;

public class ConsoleOutput : IOutputManager
{
    public void Write(string text)
    {
        Console.Write(text);
    }

    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
}