using Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public FilePath ConnectionPath { get; }

    public LocalFileSystem(FilePath connectionPath)
    {
        ConnectionPath = connectionPath;
    }

    public IEnumerable<IFileSystemComponent> GetComponents(FilePath path)
    {
        string fullPath = GetWindowsFullPath(path);
        return Directory.EnumerateFileSystemEntries(fullPath, "*", new EnumerationOptions()).Select<string, IFileSystemComponent>(component =>
        {
            if (Directory.Exists(component))
            {
                string name = component.Substring(component.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                FilePath directoryPath = path.Join(new FilePath(name));
                return new DirectoryFileSystemComponent(this, directoryPath);
            }

            return new FileFileSystemComponent(Path.GetFileName(component));
        });
    }

    public string FileRead(FilePath path)
    {
        string filePath = GetWindowsFullPath(path);
        string readText = File.ReadAllText(filePath);

        return readText;
    }

    public void FileMove(FilePath source, FilePath destination)
    {
        string sourcePath = GetWindowsFullPath(source);
        string destinationPath = GetWindowsFullPath(destination);

        File.Move(sourcePath, destinationPath);
    }

    public void FileCopy(FilePath source, FilePath destination)
    {
        string sourcePath = GetWindowsFullPath(source);
        string destinationPath = GetWindowsFullPath(destination);

        File.Copy(sourcePath, destinationPath);
    }

    public void FileDelete(FilePath path)
    {
        string filePath = GetWindowsFullPath(path);

        File.Delete(filePath);
    }

    public bool FileExists(FilePath path)
    {
        FilePath fullPath = ConnectionPath.Join(path);
        string fullWindowsPath = GetWindowsFullPath(fullPath);
        return File.Exists(fullWindowsPath);
    }

    public bool DirectoryExists(FilePath path)
    {
        FilePath fullPath = ConnectionPath.Join(path);
        string fullWindowsPath = GetWindowsFullPath(fullPath);
        return Directory.Exists(fullWindowsPath);
    }

    private string GetWindowsFullPath(FilePath path)
    {
        if (path.Segments.Count == 0)
        {
            return string.Empty;
        }

        string root = string.Empty;
        int start = 0;
        string[] segments = path.Segments.ToArray();
        if (path.IsAbsolute)
        {
            if (segments[0].Length == 1)
            {
                if (char.IsLetter(segments[0][0]))
                {
                    root = segments[0] + ":" + Path.DirectorySeparatorChar;
                    start = 1;
                }
            }
        }
        else
        {
            root = Path.DirectorySeparatorChar.ToString();
        }

        string relative = Path.Combine(segments.Skip(start).ToArray());

        return Path.Combine(root, relative);
    }
}