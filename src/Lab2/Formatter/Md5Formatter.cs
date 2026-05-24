namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public class Md5Formatter : IMessageFormatter
{
    private readonly IMessageFormatter _formatter;

    public Md5Formatter(IMessageFormatter formatter)
    {
        _formatter = formatter;
    }

    public void WriteHeader(string header)
    {
        _formatter.WriteHeader("# " + header + "\n\n");
    }

    public void WriteBody(string body)
    {
        _formatter.WriteBody(body);
    }
}