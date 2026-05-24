using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links.Tree.List;

public class DepthLink : FlagLinkBase
{
    private readonly TreeListBuilder _builder;

    public DepthLink(TreeListBuilder commandBuilder)
    {
        _builder = commandBuilder;
    }

    public override ParseResult Apply(ArgsIterator iterator)
    {
        string? argument = iterator.Peek();
        if (argument != "-d")
        {
            return CallNext(iterator);
        }

        iterator.Next();
        argument = iterator.Peek();
        if (argument != null)
        {
            int depth = int.Parse(argument);
            _builder.AddDepth(depth);
        }

        iterator.Next();
        return First.Apply(iterator);
    }
}