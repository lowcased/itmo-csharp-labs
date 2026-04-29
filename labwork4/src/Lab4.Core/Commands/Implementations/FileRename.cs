using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public class FileRename : ICommand
{
    private readonly FilePath _path;
    private readonly string _name;

    public FileRename(FilePath path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandResult Execute(Context context)
    {
        if (context.FileSystem != null)
        {
            if (context.FileSystem.FileExists(context.GetAbsolutePath(_path)))
            {
                FilePath parentDirectory = _path.GetParentDirectory();
                FilePath newPath = parentDirectory.Join(new FilePath(_name));
                var move = new FileMove(_path, newPath);
                move.Execute(context);
                return new CommandResult.Success();
            }

            return new CommandResult.Fail("File not found");
        }

        return new CommandResult.Fail("File system is not connected");
    }
}