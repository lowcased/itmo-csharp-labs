namespace Itmo.ObjectOrientedProgramming.Lab3.Fights;

public record FightResult
{
    private FightResult() { }

    public sealed record FirstPlayerWon : FightResult;

    public sealed record SecondPlayerWon : FightResult;

    public sealed record Draw : FightResult;
}