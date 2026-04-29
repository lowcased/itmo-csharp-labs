using Lab5.Domain.Accounts;
using Lab5.Domain.History;
using Lab5.Domain.Results;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Operations;

public class Replenish : IOperation
{
    public Replenish(OperationId id, Money value)
    {
        Value = value;
        Id = id;
    }

    public OperationId Id { get; }

    public Money Value { get; }

    public OperationData? Data { get; private set; }

    public IOperationResult Execute(BankAccount account)
    {
        Data = new ReplenishData(Id, account.Id, DateTime.Now, Value.Value);
        return account.Replenish(Value);
    }
}