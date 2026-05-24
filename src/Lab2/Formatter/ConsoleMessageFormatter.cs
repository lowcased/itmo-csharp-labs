namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public class ConsoleMessageFormatter : IMessageFormatter
{
    public void WriteHeader(string header)
    {
        Console.Write(header);
    }

    public void WriteBody(string body)
    {
        Console.Write(body);
    }
}