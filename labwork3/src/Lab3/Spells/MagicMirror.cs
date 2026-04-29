using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        int attack = creature.AttackValue.Value;
        creature.SetAttack(creature.HealthValue.Value);
        creature.SetHealth(attack);
        return creature;
    }
}