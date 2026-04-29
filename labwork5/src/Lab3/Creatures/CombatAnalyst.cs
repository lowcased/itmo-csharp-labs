namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : ICreature
{
    public AttackIndicator AttackValue { get; set; }

    public HealthIndicator HealthValue { get; set; }

    private const int AttackIncrease = 2;

    public CombatAnalyst(AttackIndicator attack, HealthIndicator health)
    {
        AttackValue = attack;
        HealthValue = health;
    }

    public void Attack(ICreature target)
    {
        AttackValue = new AttackIndicator(AttackValue.Value + AttackIncrease);
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
        return new CombatAnalyst(AttackValue, HealthValue);
    }
}