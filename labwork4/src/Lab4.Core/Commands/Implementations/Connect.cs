using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public class Connect : ICommand
{
    private readonly IFileSystem _fileSystem;

    public Connect(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public CommandResult Execute(Context context)
    {
        context.Connect(_fileSystem);
        return new CommandResult.Success();
    }
}