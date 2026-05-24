namespace Lab5.Domain.ValueObjects;

public record struct AccountNumber
{
    public AccountNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }
}