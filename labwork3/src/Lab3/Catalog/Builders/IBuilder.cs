using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

public interface IBuilder
{
    IBuilder AddModifier(IModifierApplier applier);

    IBuilder SetAttack(int value);

    IBuilder SetHealth(int value);

    ICreature Build();
}