using Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Factories;

public class ViciousFighterFactory : ICreatureFactory
{
    private const int DefaultAttack = 1;

    private const int DefaultHealth = 6;

    public BaseCreatureBuilder CreateBuilder()
    {
        var builder = new ViciousFighterBuilder();
        builder.SetAttack(DefaultAttack)
               .SetHealth(DefaultHealth);

        return builder;
    }
}