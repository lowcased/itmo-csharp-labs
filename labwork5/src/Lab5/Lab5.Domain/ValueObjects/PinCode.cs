namespace Lab5.Domain.ValueObjects;

public record struct PinCode
{
    public PinCode(string value)
    {
        Value = value;
    }

    public string Value { get; }
}