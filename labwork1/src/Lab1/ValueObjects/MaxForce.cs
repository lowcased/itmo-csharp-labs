namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record MaxForce
{
    public double Value { get; }

    public MaxForce(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Max force cannot be negative.");
        }

        Value = value;
    }
}