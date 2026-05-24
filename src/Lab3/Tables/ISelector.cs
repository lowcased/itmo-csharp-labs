using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public interface ISelector
{
    ICreature SelectCreature(IReadOnlyList<ICreature> creatures);
}