using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public class MasterOfAmuletsBuilder : BaseCreatureBuilder
{
    private const int DefaultAttack = 5;

    private const int DefaultHealth = 2;

    protected override ICreature Create()
    {
        var attackValue = new AttackIndicator(DefaultAttack);
        var healthValue = new HealthIndicator(DefaultHealth);
        var attackSkill = new AttackSkill();
        var magicShield = new MagicShield();
        ICreature creature = new MasterOfAmulets(attackValue, healthValue);
        ICreature modifiedCreature = attackSkill.Apply(creature);
        creature = magicShield.Apply(modifiedCreature);
        return creature;
    }
}