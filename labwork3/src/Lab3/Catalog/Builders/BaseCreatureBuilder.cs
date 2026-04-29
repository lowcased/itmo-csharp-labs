using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

public abstract class BaseCreatureBuilder : IBuilder
{
    protected int Attack { get; private set; }

    protected int Health { get; private set; }

    private readonly List<IModifierApplier> _modifiers = new();

    public IBuilder AddModifier(IModifierApplier applier)
    {
        _modifiers.Add(applier);
        return this;
    }

    public IBuilder SetAttack(int value)
    {
        Attack = value;
        return this;
    }

    public IBuilder SetHealth(int value)
    {
        Health = value;
        return this;
    }

    public ICreature Build()
    {
        ICreature creature = Create();

        foreach (IModifierApplier modifier in _modifiers)
        {
            creature = modifier.Apply(creature);
        }

        return creature;
    }

    protected abstract ICreature Create();
}