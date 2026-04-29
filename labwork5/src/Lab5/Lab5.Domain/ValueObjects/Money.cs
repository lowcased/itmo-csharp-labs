namespace Lab5.Domain.ValueObjects;

public record Money
{
    public Money(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative");
        }

        Value = value;
    }

    public decimal Value { get; }

    public static Money operator -(Money left, Money right)
    {
        decimal value = left.Value - right.Value;
        return new Money(value);
    }

    public static Money operator +(Money left, Money right)
    {
        decimal value = left.Value + right.Value;
        return new Money(value);
    }
}