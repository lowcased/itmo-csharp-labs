namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class Creature : ICreature
{
    public AttackIndicator AttackValue { get; set; }

    public HealthIndicator HealthValue { get; set; }

    public Creature(AttackIndicator attack, HealthIndicator health)
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
        return new Creature(AttackValue, HealthValue);
    }
}