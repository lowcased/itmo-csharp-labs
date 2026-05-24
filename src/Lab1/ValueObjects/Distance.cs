namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class Distance
{
    public double Value { get; }

    public Distance(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Distance cannot be negative");
        }

        Value = value;
    }
}