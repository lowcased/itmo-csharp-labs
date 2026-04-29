using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

public class CreatureBuilder : BaseCreatureBuilder
{
    protected override ICreature Create()
    {
        var attack = new AttackIndicator(Attack);
        var health = new HealthIndicator(Health);
        return new Creature(attack, health);
    }
}