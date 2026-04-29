using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class FileMoveBuilder : ICommandBuilder
{
    private FilePath? _source;
    private FilePath? _destination;

    public FileMoveBuilder AddSourcePath(FilePath source)
    {
        _source = source;
        return this;
    }

    public FileMoveBuilder AddDestinationPath(FilePath destination)
    {
        _destination = destination;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_source == null || _destination == null)
        {
            return new CommandBuilderResult.Fail();
        }

        return new CommandBuilderResult.Success(new FileMove(_source, _destination));
    }
}