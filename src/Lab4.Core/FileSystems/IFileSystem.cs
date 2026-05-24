using Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    FilePath ConnectionPath { get; }

    IEnumerable<IFileSystemComponent> GetComponents(FilePath path);

    string FileRead(FilePath path);

    void FileMove(FilePath source, FilePath destination);

    void FileCopy(FilePath source, FilePath destination);

    void FileDelete(FilePath path);

    bool FileExists(FilePath path);

    bool DirectoryExists(FilePath path);
}