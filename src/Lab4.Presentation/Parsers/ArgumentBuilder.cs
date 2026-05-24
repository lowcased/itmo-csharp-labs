using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class ArgumentBuilder
{
    private readonly ICommandBuilder _commandBuilder;
    private IParserLink? _firstPositional;
    private IParserLink? _lastPositional;
    private FlagLinkBase? _firstFlag;
    private FlagLinkBase? _lastFlag;

    public ArgumentBuilder(ICommandBuilder commandBuilder)
    {
        _commandBuilder = commandBuilder;
    }

    public ArgumentBuilder AddPositional(IParserLink link)
    {
        if (_lastPositional != null)
        {
            _lastPositional.AddNext(link);
        }
        else
        {
            _firstPositional = link;
        }

        _lastPositional = link;
        return this;
    }

    public ArgumentBuilder AddFlag(FlagLinkBase link)
    {
        if (_firstFlag == null)
        {
            _firstFlag = link;
        }

        if (_lastFlag != null)
        {
            _lastFlag.AddNext(link);
        }

        _lastFlag = link;
        _lastFlag.SetFirstFlag(_firstFlag);
        return this;
    }

    public IParserLink Build()
    {
        var terminal = new TerminalArgLink(_commandBuilder);
        if (_firstPositional != null && _lastPositional != null)
        {
            if (_firstFlag != null && _lastFlag != null)
            {
                _lastPositional.AddNext(_firstFlag);
                _lastFlag.AddNext(terminal);
            }
            else
            {
                _lastPositional.AddNext(terminal);
            }

            return _firstPositional;
        }

        if (_firstFlag != null && _lastFlag != null)
        {
            _lastFlag.AddNext(terminal);
            return _firstFlag;
        }

        return terminal;
    }
}