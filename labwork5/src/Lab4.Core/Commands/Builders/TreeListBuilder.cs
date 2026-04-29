using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class TreeListBuilder : ICommandBuilder
{
    private int _depth = 1;

    public TreeListBuilder AddDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public CommandBuilderResult Build()
    {
        if (_depth < 0)
        {
            return new CommandBuilderResult.Fail();
        }

        return new CommandBuilderResult.Success(new TreeList(_depth));
    }
}