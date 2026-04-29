namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public record AttackIndicator
{
    public int Value { get; private set; }

    public AttackIndicator(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Attack must be greater than zero");
        }

        Value = value;
    }
}