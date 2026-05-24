using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Fights;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class FightTests
{
    [Fact]
    public void FightResult_ShouldShowWinner()
    {
        // Arrange
        var selector = new RandomSelector();
        var attackIndicator1 = new AttackIndicator(10);
        var healthIndicator1 = new HealthIndicator(10);
        var attackIndicator2 = new AttackIndicator(1);
        var healthIndicator2 = new HealthIndicator(1);
        var creature1 = new Creature(attackIndicator1, healthIndicator1);
        var creature2 = new Creature(attackIndicator2, healthIndicator2);
        var creatures1 = new List<ICreature>();
        var creatures2 = new List<ICreature>();
        creatures1.Add(creature1);
        creatures2.Add(creature2);
        var table1 = new Table(selector, creatures1);
        var table2 = new Table(selector, creatures2);
        var fight = new Fight(table1, table2);

        // Act
        FightResult result = fight.Start();

        // Assert
        Assert.IsType<FightResult.FirstPlayerWon>(result);
    }

    [Fact]
    public void MimicChest_ShouldLoseToViciousFighter()
    {
        // Arrange
        var selector = new RandomSelector();
        var attackIndicator1 = new AttackIndicator(10);
        var healthIndicator1 = new HealthIndicator(10);
        var attackIndicator2 = new AttackIndicator(1);
        var healthIndicator2 = new HealthIndicator(1);
        var creature1 = new Creature(attackIndicator1, healthIndicator1);
        var creature2 = new Creature(attackIndicator2, healthIndicator2);
        var creatures1 = new List<ICreature>();
        var creatures2 = new List<ICreature>();
        creatures1.Add(creature1);
        creatures2.Add(creature2);
        var table1 = new Table(selector, creatures1);
        var table2 = new Table(selector, creatures2);
        var fight = new Fight(table1, table2);

        // Act
        FightResult result = fight.Start();

        // Assert
        Assert.IsType<FightResult.FirstPlayerWon>(result);
    }
}