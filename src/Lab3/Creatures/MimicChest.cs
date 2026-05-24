namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : ICreature
{
    public AttackIndicator AttackValue { get; set; }

    public HealthIndicator HealthValue { get; set; }

    public MimicChest(AttackIndicator attack, HealthIndicator health)
    {
        AttackValue = attack;
        HealthValue = health;
    }

    public void Attack(ICreature target)
    {
        AttackValue = new AttackIndicator(Math.Max(AttackValue.Value, target.AttackValue.Value));
        HealthValue = new HealthIndicator(Math.Max(HealthValue.Value, target.HealthValue.Value));
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

    public ICreature Clone()
    {
        return new MimicChest(AttackValue, HealthValue);
    }
}