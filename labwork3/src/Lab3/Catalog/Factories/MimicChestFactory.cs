using Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Factories;

public class MimicChestFactory : ICreatureFactory
{
    private const int DefaultAttack = 1;

    private const int DefaultHealth = 1;

    public BaseCreatureBuilder CreateBuilder()
    {
        var builder = new MimicChestBuilder();
        builder.SetAttack(DefaultAttack)
               .SetHealth(DefaultHealth);

        return builder;
    }
}