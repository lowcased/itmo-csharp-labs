using Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Factories;

public class CombatAnalystFactory : ICreatureFactory
{
    private const int DefaultAttack = 2;

    private const int DefaultHealth = 4;

    public BaseCreatureBuilder CreateBuilder()
    {
        var builder = new CombatAnalystBuilder();
        builder.SetAttack(DefaultAttack)
               .SetHealth(DefaultHealth);

        return builder;
    }
}