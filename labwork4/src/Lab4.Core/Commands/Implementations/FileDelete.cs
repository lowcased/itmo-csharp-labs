using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public class FileDelete : ICommand
{
    private readonly FilePath _path;

    public FileDelete(FilePath path)
    {
        _path = path;
    }

    public CommandResult Execute(Context context)
    {
        if (context.FileSystem != null)
        {
            if (context.FileSystem.FileExists(context.GetAbsolutePath(_path)))
            {
                context.FileSystem.FileDelete(_path);
                return new CommandResult.Success();
            }

            return new CommandResult.Fail("File not found");
        }

        return new CommandResult.Fail("File system is not connected");
    }
}