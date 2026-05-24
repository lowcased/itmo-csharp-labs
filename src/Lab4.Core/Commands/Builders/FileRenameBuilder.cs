using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class FileRenameBuilder : ICommandBuilder
{
    private FilePath? _path;
    private string? _name;

    public FileRenameBuilder AddPath(FilePath path)
    {
        _path = path;
        return this;
    }

    public FileRenameBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_path == null || _name == null)
        {
            return new CommandBuilderResult.Fail();
        }

        return new CommandBuilderResult.Success(new FileRename(_path, _name));
    }
}