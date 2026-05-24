using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public class TreeGoto : ICommand
{
    private readonly FilePath _path;

    public TreeGoto(FilePath path)
    {
        _path = path;
    }

    public CommandResult Execute(Context context)
    {
        if (context.FileSystem != null)
        {
            if (context.FileSystem.DirectoryExists(context.GetAbsolutePath(_path)))
            {
                context.ChangeDirectory(_path);
                return new CommandResult.Success();
            }

            return new CommandResult.Fail("Directory not found");
        }

        return new CommandResult.Fail("File system is not connected");
    }
}