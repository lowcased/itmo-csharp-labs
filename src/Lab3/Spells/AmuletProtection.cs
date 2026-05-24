using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class AmuletProtection : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        var modifier = new MagicShield();
        ICreature newCreature = modifier.Apply(creature);
        return newCreature;
    }
}