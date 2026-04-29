namespace Lab5.Domain.Operations;

public readonly record struct OperationId(Guid Value)
{
    public static readonly OperationId Default = new(Guid.Empty);
}