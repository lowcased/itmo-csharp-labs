namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ViciousFighter : ICreature
{
    public AttackIndicator AttackValue { get; set; }

    public HealthIndicator HealthValue { get; set; }

    public ViciousFighter(AttackIndicator attack, HealthIndicator health)
    {
        AttackValue = attack;
        HealthValue = health;
    }

    public void Attack(ICreature target)
    {
        target.TakeDamage(AttackValue.Value);
    }

    public void TakeDamage(int damage)
    {
        if (HealthValue.Value - damage > 0)
        {
            HealthValue = new HealthIndicator(HealthValue.Value - damage);
            AttackValue = new AttackIndicator(AttackValue.Value * 2);
        }
        else
        {
            HealthValue = new HealthIndicator(0);
        }
    }

    public ICreature Clone()
    {
        return new ViciousFighter(AttackValue, HealthValue);
    }
}