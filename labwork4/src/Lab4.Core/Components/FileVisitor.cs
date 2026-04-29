using Itmo.ObjectOrientedProgramming.Lab4.Core.OutputManager;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Components;

public class FileVisitor : IFileSystemComponentVisitor
{
    private readonly VisitorSymbols _symbols;
    private readonly IOutputManager _outputManager;
    private readonly int _maxDepth;
    private int _depth;

    public FileVisitor(IOutputManager outputManager, int maxDepth, VisitorSymbols? symbols = null)
    {
        _outputManager = outputManager;
        _maxDepth = maxDepth;
        if (symbols is null)
        {
            _symbols = new VisitorSymbols();
        }
        else
        {
            _symbols = symbols;
        }
    }

    public void Visit(FileFileSystemComponent component)
    {
        string padding = new string(_symbols.PaddingSymbol, _depth);
        _outputManager.Write(padding);
        _outputManager.WriteLine(_symbols.FileSymbol + " " + component.Name);
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        string padding = new string(_symbols.PaddingSymbol, _depth);
        _outputManager.Write(padding);
        _outputManager.WriteLine(_symbols.DirectorySymbol + " " + component.Name);

        if (_depth < _maxDepth)
        {
            _depth++;
            foreach (IFileSystemComponent child in component.Components)
            {
                child.Accept(this);
            }

            _depth--;
        }
    }
}