namespace Lab5.Domain.Accounts;

public readonly record struct AccountId(Guid Value)
{
    public static readonly AccountId Default = new(Guid.Empty);
}