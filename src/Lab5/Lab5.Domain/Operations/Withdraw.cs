using Lab5.Domain.Accounts;
using Lab5.Domain.History;
using Lab5.Domain.Results;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Operations;

public class Withdraw : IOperation
{
    public Withdraw(OperationId id, Money value)
    {
        Value = value;
        Id = id;
    }

    public OperationId Id { get; }

    public Money Value { get; }

    public OperationData? Data { get; private set; }

    public IOperationResult Execute(BankAccount account)
    {
        Data = new WithdrawData(Id, account.Id, DateTime.Now, Value.Value);
        return account.Withdraw(Value);
    }
}