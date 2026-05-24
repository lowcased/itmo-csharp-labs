namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Printers;

public class ConsoleFilePrinter : IFilePrinter
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}