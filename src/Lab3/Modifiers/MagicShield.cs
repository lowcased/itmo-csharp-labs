using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShield : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        var modifiedCreature = new MagicShieldModifier(creature, false);
        return modifiedCreature;
    }
}