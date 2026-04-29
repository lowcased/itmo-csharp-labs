using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Printers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public class FileShow : ICommand
{
    private readonly FilePath _path;
    private readonly IFilePrinter _printer;

    public FileShow(FilePath path, IFilePrinter printer)
    {
        _path = path;
        _printer = printer;
    }

    public CommandResult Execute(Context context)
    {
        if (context.FileSystem != null)
        {
            if (context.FileSystem.FileExists(context.GetAbsolutePath(_path)))
            {
                string readText = context.FileSystem.FileRead(context.GetAbsolutePath(_path));
                _printer.Print(readText);
                return new CommandResult.Success();
            }

            return new CommandResult.Fail("File not found");
        }

        return new CommandResult.Fail("File system is not connected");
    }
}