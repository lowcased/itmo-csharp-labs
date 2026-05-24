using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class FileCopyBuilder : ICommandBuilder
{
    private FilePath? _source;
    private FilePath? _destination;

    public FileCopyBuilder AddSourcePath(FilePath source)
    {
        _source = source;
        return this;
    }

    public FileCopyBuilder AddDestinationPath(FilePath destination)
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

        return new CommandBuilderResult.Success(new FileCopy(_source, _destination));
    }
}