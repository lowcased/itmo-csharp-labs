namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class ArgsIterator
{
    private readonly string[] _args;
    private int _idx = 0;

    public ArgsIterator(string[] args)
    {
        _args = args;
    }

    public string? Next()
    {
        if (_idx >= _args.Length)
        {
            return null;
        }

        return _args[_idx++];
    }

    public string? Peek()
    {
        if (_idx >= _args.Length)
        {
            return null;
        }

        return _args[_idx];
    }
}