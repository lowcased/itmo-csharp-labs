namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MasterOfAmulets : ICreature
{
    public AttackIndicator AttackValue
    {
        get => _creature.AttackValue;
        set => _creature.AttackValue = value;
    }

    public HealthIndicator HealthValue
    {
        get => _creature.HealthValue;
        set => _creature.HealthValue = value;
    }

    private readonly Creature _creature;

    public MasterOfAmulets(AttackIndicator attack, HealthIndicator health)
    {
        _creature = new Creature(attack, health);
    }

    public void Attack(ICreature target)
    {
        target.TakeDamage(_creature.AttackValue.Value);
    }

    public void TakeDamage(int damage)
    {
        if (HealthValue.Value - damage > 0)
        {
            HealthValue = new HealthIndicator(HealthValue.Value - damage);
        }
        else
        {
            HealthValue = new HealthIndicator(0);
        }
    }

    public void SetAttack(int value)
    {
        AttackValue = new AttackIndicator(value);
    }

    public void SetHealth(int value)
    {
        HealthValue = new HealthIndicator(value);
    }

    public ICreature Clone()
    {
        return new MasterOfAmulets(_creature.AttackValue, _creature.HealthValue);
    }
}