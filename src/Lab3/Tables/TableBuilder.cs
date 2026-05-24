using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class TableBuilder
{
    private const int MaxNumOfCreatures = 7;
    private readonly List<ICreature> _creatures = new();
    private ISelector _selector = new RandomSelector();

    public void SetSelector(ISelector selector)
    {
        _selector = selector;
    }

    public void AddCreature(ICreature creature)
    {
        if (_creatures.Count <= MaxNumOfCreatures)
        {
            _creatures.Add(creature);
        }
    }

    public Table Build()
    {
        return new Table(_selector, _creatures);
    }
}