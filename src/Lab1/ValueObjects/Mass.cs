namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record Mass
{
    public double Value { get; }

    public Mass(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Mass must be greater than zero");
        }

        Value = value;
    }
}