namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public class FileMessageFormatter : IMessageFormatter
{
    private readonly string _path;

    public FileMessageFormatter(string path)
    {
        _path = path;
    }

    public void WriteHeader(string header)
    {
        Write(header);
    }

    public void WriteBody(string body)
    {
        Write(body);
    }

    private void Write(string text)
    {
        File.AppendAllText(_path, text);
    }
}