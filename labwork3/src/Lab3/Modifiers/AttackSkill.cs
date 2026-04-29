using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackSkill : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        var modifiedCreature = new AttackSkillModifier(creature);
        return modifiedCreature;
    }
}