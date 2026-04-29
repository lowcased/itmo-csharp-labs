using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class RandomSelector : ISelector
{
    public ICreature SelectCreature(IReadOnlyList<ICreature> creatures)
    {
        int randIndex = RandomNumberGenerator.GetInt32(creatures.Count);
        return creatures[randIndex];
    }
}