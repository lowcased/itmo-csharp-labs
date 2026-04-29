namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class HealthIndicator
{
    public int Value { get; private set; }

    public HealthIndicator(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Health must be greater than zero");
        }

        Value = value;
    }
}