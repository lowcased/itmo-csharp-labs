using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public class FileMove : ICommand
{
    private readonly FilePath _sourcePath;
    private readonly FilePath _destinationPath;

    public FileMove(FilePath sourcePath, FilePath destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResult Execute(Context context)
    {
        if (context.FileSystem != null)
        {
            if (context.FileSystem.FileExists(context.GetAbsolutePath(_sourcePath)))
            {
                if (context.FileSystem.FileExists(context.GetAbsolutePath(_destinationPath)))
                {
                    return new CommandResult.Fail("Destination file already exists");
                }

                context.FileSystem.FileMove(_sourcePath, _destinationPath);
                return new CommandResult.Success();
            }

            return new CommandResult.Fail("Source file not found");
        }

        return new CommandResult.Fail("File system is not connected");
    }
}