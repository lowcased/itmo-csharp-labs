namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    AttackIndicator AttackValue { get; set; }

    HealthIndicator HealthValue { get; set; }

    void Attack(ICreature target) { }

    void TakeDamage(int damage) { }

    ICreature Clone();
}