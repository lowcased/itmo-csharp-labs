namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystemFactory : IFileSystemFactory
{
    public IFileSystem Create(FilePath connectionPath)
    {
        var fileSystem = new LocalFileSystem(connectionPath);
        return fileSystem;
    }
}