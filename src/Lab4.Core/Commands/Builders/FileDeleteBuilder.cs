using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class FileDeleteBuilder : ICommandBuilder
{
    private FilePath? _path;

    public FileDeleteBuilder AddPath(FilePath path)
    {
        _path = path;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_path == null)
        {
            return new CommandBuilderResult.Fail();
        }

        return new CommandBuilderResult.Success(new FileDelete(_path));
    }
}