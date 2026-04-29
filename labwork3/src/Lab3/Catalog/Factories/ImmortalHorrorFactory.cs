using Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Factories;

public class ImmortalHorrorFactory : ICreatureFactory
{
    private const int DefaultAttack = 4;

    private const int DefaultHealth = 4;

    private const bool DefaultImmortality = false;

    public BaseCreatureBuilder CreateBuilder()
    {
        var builder = new ImmortalHorrorBuilder();
        builder.SetImmortality(DefaultImmortality)
               .SetAttack(DefaultAttack)
               .SetHealth(DefaultHealth);

        return builder;
    }
}