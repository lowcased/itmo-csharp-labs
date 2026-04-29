using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class ConnectBuilder : ICommandBuilder
{
    private FilePath? _address;
    private IFileSystemFactory _factory = new LocalFileSystemFactory();

    public ConnectBuilder AddAddress(FilePath address)
    {
        _address = address;
        return this;
    }

    public ConnectBuilder AddFilesystem(IFileSystemFactory factory)
    {
        _factory = factory;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_address == null)
        {
            return new CommandBuilderResult.Fail();
        }

        IFileSystem fileSystem = _factory.Create(_address);
        return new CommandBuilderResult.Success(new Connect(fileSystem));
    }
}