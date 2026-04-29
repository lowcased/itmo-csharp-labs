using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

public class ImmortalHorrorBuilder : BaseCreatureBuilder
{
    private bool _isImmortal = false;

    public ImmortalHorrorBuilder SetImmortality(bool isImmortal)
    {
        _isImmortal = isImmortal;
        return this;
    }

    protected override ICreature Create()
    {
        var attack = new AttackIndicator(Attack);
        var health = new HealthIndicator(Health);
        return new ImmortalHorror(attack, health, _isImmortal);
    }
}