namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}