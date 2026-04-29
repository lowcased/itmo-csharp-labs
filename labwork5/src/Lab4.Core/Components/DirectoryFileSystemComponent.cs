using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public string Name { get; }

    public IEnumerable<IFileSystemComponent> Components { get; private set; }

    public DirectoryFileSystemComponent(IFileSystem fileSystem, FilePath path)
    {
        Name = path.GetName();
        Components = fileSystem.GetComponents(path);
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}