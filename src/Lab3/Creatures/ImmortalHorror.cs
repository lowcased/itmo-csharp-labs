namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : ICreature
{
    public AttackIndicator AttackValue { get; set; }

    public HealthIndicator HealthValue { get; set; }

    private bool _isUsed;

    public ImmortalHorror(AttackIndicator attack, HealthIndicator health, bool isUsed)
    {
        AttackValue = attack;
        HealthValue = health;
        _isUsed = isUsed;
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
            if (!_isUsed)
            {
                HealthValue = new HealthIndicator(1);
                _isUsed = true;
            }
            else
            {
                HealthValue = new HealthIndicator(0);
            }
        }
    }

    public ICreature Clone()
    {
        return new ImmortalHorror(AttackValue, HealthValue, _isUsed);
    }
}