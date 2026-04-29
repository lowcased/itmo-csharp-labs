using Itmo.ObjectOrientedProgramming.Lab3.Catalog.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog.Factories;

public interface ICreatureFactory
{
    BaseCreatureBuilder CreateBuilder();
}