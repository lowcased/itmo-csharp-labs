using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class StaminaPotion : ISpell
{
    private const int HealthIncrease = 5;

    public ICreature Apply(ICreature creature)
    {
        creature.SetHealth(creature.AttackValue.Value + HealthIncrease);
        return creature;
    }
}