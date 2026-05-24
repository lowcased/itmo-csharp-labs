using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public class ImmortalHorrorBuilder : BaseCreatureBuilder
{
    private const int DefaultAttack = 4;

    private const int DefaultHealth = 4;

    protected override ICreature Create()
    {
        var attackValue = new AttackIndicator(DefaultAttack);
        var healthValue = new HealthIndicator(DefaultHealth);
        return new ImmortalHorror(attackValue, healthValue, false);
    }
}