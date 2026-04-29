using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class StrengthPotion : ISpell
{
    private const int AttackIncrease = 5;

    public ICreature Apply(ICreature creature)
    {
        creature.SetAttack(creature.AttackValue.Value + AttackIncrease);
        return creature;
    }
}