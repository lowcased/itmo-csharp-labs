using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public abstract class BaseCreatureBuilder
{
    private readonly List<IModifierApplier> _modifiers = new List<IModifierApplier>();

    private int? _attack;

    private int? _health;

    public void AddModifier(IModifierApplier modifierApplier)
    {
        _modifiers.Add(modifierApplier);
    }

    public void SetAttack(int value)
    {
        _attack = value;
    }

    public void SetHealth(int value)
    {
        _health = value;
    }

    public ICreature Build()
    {
        ICreature creature = Create();
        if (_attack.HasValue)
        {
            creature.AttackValue = new AttackIndicator(_attack.Value);
        }

        if (_health.HasValue)
        {
            creature.HealthValue = new HealthIndicator(_health.Value);
        }

        foreach (IModifierApplier modifier in _modifiers)
        {
            creature = modifier.Apply(creature);
        }

        return creature;
    }

    protected abstract ICreature Create();
}