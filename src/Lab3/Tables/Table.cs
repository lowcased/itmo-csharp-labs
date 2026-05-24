using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class Table
{
    private readonly ISelector _selector;
    private readonly IReadOnlyList<ICreature> _creatures;

    public Table(ISelector selector, IReadOnlyList<ICreature> creatures)
    {
        _selector = selector;
        _creatures = creatures;
    }

    public ICreature? GetAttacker()
    {
        var attackingCreatures = new List<ICreature>();
        foreach (ICreature creature in _creatures)
        {
            if (creature.HealthValue.Value > 0 && creature.AttackValue.Value > 0)
            {
                attackingCreatures.Add(creature);
            }
        }

        if (attackingCreatures.Count == 0)
        {
            return null;
        }

        return _selector.SelectCreature(_creatures);
    }

    public ICreature? GetAttacked()
    {
        var attackedCreatures = new List<ICreature>();
        foreach (ICreature creature in _creatures)
        {
            if (creature.HealthValue.Value > 0)
            {
                attackedCreatures.Add(creature);
            }
        }

        if (attackedCreatures.Count == 0)
        {
            return null;
        }

        return _selector.SelectCreature(_creatures);
    }

    public void ApplySpell(int creatureId, ISpell spell)
    {
        spell.Apply(_creatures[creatureId]);
    }

    public Table Clone()
    {
        List<ICreature> creaturesClons = new();
        foreach (ICreature creature in _creatures)
        {
            ICreature creaturePrototype = creature.Clone();
            creaturesClons.Add(creaturePrototype);
        }

        var table = new Table(_selector, creaturesClons);
        return table;
    }
}