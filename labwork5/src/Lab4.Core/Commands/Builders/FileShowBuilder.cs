using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Printers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class FileShowBuilder : ICommandBuilder
{
    private FilePath? _path;
    private IFilePrinter? _printer;

    public FileShowBuilder AddPath(FilePath path)
    {
        _path = path;
        return this;
    }

    public FileShowBuilder AddPrinter(IFilePrinter printer)
    {
        _printer = printer;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_path == null || _printer == null)
        {
            return new CommandBuilderResult.Fail();
        }

        return new CommandBuilderResult.Success(new FileShow(_path, _printer));
    }
}