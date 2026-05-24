using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public class MimicChestBuilder : BaseCreatureBuilder
{
    private const int DefaultAttack = 1;

    private const int DefaultHealth = 1;

    protected override ICreature Create()
    {
        var attackValue = new AttackIndicator(DefaultAttack);
        var healthValue = new HealthIndicator(DefaultHealth);
        return new MimicChest(attackValue, healthValue);
    }
}