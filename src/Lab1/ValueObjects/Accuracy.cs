namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record Accuracy
{
    public double Value { get; }

    public Accuracy(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Accuracy must be greater than zero");
        }

        Value = value;
    }
}