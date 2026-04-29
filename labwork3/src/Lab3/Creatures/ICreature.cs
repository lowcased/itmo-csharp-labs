namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    AttackIndicator AttackValue { get; }

    HealthIndicator HealthValue { get; }

    void Attack(ICreature target) { }

    void TakeDamage(int damage) { }

    void SetHealth(int value) { }

    void SetAttack(int value) { }

    ICreature Clone();
}