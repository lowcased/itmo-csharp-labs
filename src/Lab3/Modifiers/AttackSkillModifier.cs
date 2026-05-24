using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackSkillModifier : ICreature
{
    public AttackIndicator AttackValue { get; set; }

    public HealthIndicator HealthValue { get; set; }

    private readonly ICreature _creature;

    public AttackSkillModifier(ICreature creature)
    {
        AttackValue = creature.AttackValue;
        HealthValue = creature.HealthValue;
        _creature = creature;
    }

    public void Attack(ICreature target)
    {
        _creature.Attack(target);
        if (target.HealthValue.Value > 0)
        {
            _creature.Attack(target);
        }
    }

    public ICreature Clone()
    {
        ICreature creatureClone = _creature.Clone();
        return new AttackSkillModifier(creatureClone);
    }
}