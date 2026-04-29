namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class FilePath
{
    private string[] _segments;

    public IReadOnlyList<string> Segments => _segments;

    public bool IsAbsolute { get; }

    public FilePath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            _segments = [];
            return;
        }

        if (path[0] == '/')
        {
            IsAbsolute = true;
        }

        _segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
    }

    public FilePath Join(FilePath other)
    {
        string newPathString = ToString() + "/" + other;
        var newPath = new FilePath(newPathString);
        newPath.Normalize();
        return newPath;
    }

    public string GetName()
    {
        return _segments[^1];
    }

    public FilePath GetParentDirectory()
    {
        string path = ToString();
        int index = path.LastIndexOf('/');
        if (index != -1)
        {
            return new FilePath(path.Substring(0, index));
        }

        return this;
    }

    public void Normalize()
    {
        int skipCount = 0;
        var segments = new List<string>();
        for (int i = _segments.Length - 1; i >= 0; i--)
        {
            if (_segments[i] == "..")
            {
                skipCount++;
            }
            else if (_segments[i] != ".")
            {
                if (skipCount == 0)
                {
                    segments.Add(_segments[i]);
                }
                else
                {
                    skipCount--;
                }
            }
        }

        _segments = segments.ToArray().Reverse().ToArray();
    }

    public override string ToString()
    {
        string path = string.Empty;
        if (IsAbsolute)
        {
            path = "/";
        }

        foreach (string segment in _segments)
        {
            path += segment + "/";
        }

        return path.TrimEnd('/');
    }
}