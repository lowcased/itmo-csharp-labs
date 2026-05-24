namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public interface IMessageFormatter
{
    void WriteHeader(string header);

    void WriteBody(string body);
}