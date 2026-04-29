using Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Factories;

public class MasterOfAmuletsFactory : ICreatureFactory
{
    private const int DefaultAttack = 5;

    private const int DefaultHealth = 2;

    public BaseCreatureBuilder CreateBuilder()
    {
        var builder = new MasterOfAmuletsBuilder();
        builder.SetAttack(DefaultAttack)
               .SetHealth(DefaultHealth)
               .AddModifier(new MagicShield())
               .AddModifier(new AttackSkill());

        return builder;
    }
}