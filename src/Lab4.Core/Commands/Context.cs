using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OutputManager;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class Context
{
    public IFileSystem? FileSystem { get; private set; }

    private FilePath _localPath = new(string.Empty);

    public IOutputManager OutputManager { get; private set; }

    public Context(IOutputManager output)
    {
        OutputManager = output;
    }

    public void Connect(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void Disconnect()
    {
        FileSystem = null;
        _localPath = new FilePath(string.Empty);
    }

    public void ChangeDirectory(FilePath path)
    {
        if (FileSystem == null)
        {
            return;
        }

        if (path.IsAbsolute)
        {
            _localPath = path;
        }
        else
        {
            _localPath = _localPath.Join(path);
        }
    }

    public FilePath GetAbsolutePath(FilePath path)
    {
        if (path.IsAbsolute)
        {
            return path;
        }

        return _localPath.Join(path);
    }

    public FilePath GetFullPath()
    {
        if (FileSystem == null)
        {
            return _localPath;
        }

        return FileSystem.ConnectionPath.Join(_localPath);
    }
}