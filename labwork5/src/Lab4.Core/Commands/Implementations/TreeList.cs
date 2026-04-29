using Itmo.ObjectOrientedProgramming.Lab4.Core.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public class TreeList : ICommand
{
    private readonly int _depth;

    public TreeList(int depth)
    {
        _depth = depth;
    }

    public CommandResult Execute(Context context)
    {
        if (context.FileSystem != null)
        {
            FilePath path = context.GetFullPath();
            IEnumerable<IFileSystemComponent> components = context.FileSystem.GetComponents(path);
            var directory = new DirectoryFileSystemComponent(context.FileSystem, path);
            var fileVisitor = new FileVisitor(context.OutputManager, _depth);
            directory.Accept(fileVisitor);
            return new CommandResult.Success();
        }

        return new CommandResult.Fail("File system is not connected");
    }
}