using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        int attack = creature.AttackValue.Value;
        creature.AttackValue = new AttackIndicator(creature.HealthValue.Value);
        creature.HealthValue = new HealthIndicator(attack);
        return creature;
    }
}