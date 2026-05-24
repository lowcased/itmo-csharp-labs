using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UnitTests
{
    [Fact]
    public void Creature_ShouldHaveMutableHealthAndAttack()
    {
        // Arrange
        var attackIndicator = new AttackIndicator(2);
        var healthIndicator = new HealthIndicator(4);
        var creature = new Creature(attackIndicator, healthIndicator);

        // Act
        creature.AttackValue = new AttackIndicator(5);
        creature.HealthValue = new HealthIndicator(8);

        // Assert
        Assert.Equal(5, creature.AttackValue.Value);
        Assert.Equal(8, creature.HealthValue.Value);
    }

    [Fact]
    public void Creature_ShouldNotTakeDamage_WhenAttacks()
    {
        // Arrange
        var attackIndicator1 = new AttackIndicator(2);
        var healthIndicator1 = new HealthIndicator(4);
        var attackIndicator2 = new AttackIndicator(3);
        var healthIndicator2 = new HealthIndicator(4);
        var creature = new Creature(attackIndicator1, healthIndicator1);
        var creature2 = new Creature(attackIndicator2, healthIndicator2);

        // Act
        creature.Attack(creature2);

        // Assert
        Assert.Equal(2, creature.AttackValue.Value);
        Assert.Equal(4, creature.HealthValue.Value);
    }

    [Fact]
    public void Creature_ShouldGetDamage_WhenAttacked()
    {
        // Arrange
        var attackIndicator1 = new AttackIndicator(2);
        var healthIndicator1 = new HealthIndicator(4);
        var attackIndicator2 = new AttackIndicator(3);
        var healthIndicator2 = new HealthIndicator(4);
        var creature = new Creature(attackIndicator1, healthIndicator1);
        var creature2 = new Creature(attackIndicator2, healthIndicator2);

        // Act
        creature.Attack(creature2);

        // Assert
        Assert.Equal(2, creature2.HealthValue.Value);
    }

    [Fact]
    public void CreatureWithAttackSkill_ShouldAttackTwice()
    {
        // Arrange
        var attackIndicator1 = new AttackIndicator(2);
        var healthIndicator1 = new HealthIndicator(4);
        var attackIndicator2 = new AttackIndicator(3);
        var healthIndicator2 = new HealthIndicator(5);
        var creature = new Creature(attackIndicator1, healthIndicator1);
        var creature2 = new Creature(attackIndicator2, healthIndicator2);
        var modifier = new AttackSkill();
        ICreature modifiedCreature = modifier.Apply(creature);

        // Act
        modifiedCreature.Attack(creature2);

        // Assert
        Assert.Equal(1, creature2.HealthValue.Value);
    }

    [Fact]
    public void MagicShield_ShouldSaveFromDamageOnlyOnce()
    {
        // Arrange
        var attackIndicator1 = new AttackIndicator(2);
        var healthIndicator1 = new HealthIndicator(4);
        var attackIndicator2 = new AttackIndicator(3);
        var healthIndicator2 = new HealthIndicator(5);
        var creature = new Creature(attackIndicator1, healthIndicator1);
        var creature2 = new Creature(attackIndicator2, healthIndicator2);
        var modifier = new MagicShield();
        ICreature modifiedCreature = modifier.Apply(creature2);

        // Act
        creature.Attack(modifiedCreature);
        int health = creature2.HealthValue.Value;
        creature.Attack(modifiedCreature);

        // Assert
        Assert.Equal(5, health);
        Assert.Equal(3, creature2.HealthValue.Value);
    }

    [Fact]
    public void ViciousFighter_ShouldIncreaseAttackValue_WhenAttacked()
    {
        // Arrange
        var attackIndicator1 = new AttackIndicator(2);
        var healthIndicator1 = new HealthIndicator(4);
        var attackIndicator2 = new AttackIndicator(1);
        var healthIndicator2 = new HealthIndicator(6);
        var creature = new Creature(attackIndicator1, healthIndicator1);
        var viciousFighter = new ViciousFighter(attackIndicator2, healthIndicator2);

        // Act
        creature.Attack(viciousFighter);
        creature.Attack(viciousFighter);

        // Assert
        Assert.Equal(4, viciousFighter.AttackValue.Value);
    }

    [Fact]
    public void MagicMirror_ShouldChangeAttackAndHealthValues()
    {
        // Arrange
        var attackIndicator1 = new AttackIndicator(2);
        var healthIndicator1 = new HealthIndicator(4);
        var creature = new Creature(attackIndicator1, healthIndicator1);
        var magicMirror = new MagicMirror();

        // Act
        ICreature spelledCreature = magicMirror.Apply(creature);

        // Assert
        Assert.Equal(4, spelledCreature.AttackValue.Value);
        Assert.Equal(2, spelledCreature.HealthValue.Value);
    }
}