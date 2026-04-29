using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShieldModifier : ICreature
{
    public AttackIndicator AttackValue { get; set; }

    public HealthIndicator HealthValue { get; set; }

    private readonly ICreature _creature;

    private bool _isUsed;

    public MagicShieldModifier(ICreature creature, bool isUsed)
    {
        AttackValue = creature.AttackValue;
        HealthValue = creature.HealthValue;
        _creature = creature;
        _isUsed = isUsed;
    }

    public void TakeDamage(int damage)
    {
        if (_isUsed)
        {
            _creature.TakeDamage(damage);
        }
        else
        {
            _isUsed = true;
        }
    }

    public ICreature Clone()
    {
        ICreature creatureClone = _creature.Clone();
        return new MagicShieldModifier(creatureClone, _isUsed);
    }
}