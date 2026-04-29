using Lab5.Domain.Accounts;
using Lab5.Domain.Operations;

namespace Lab5.Domain.History;

public class ReplenishData : OperationData
{
    public ReplenishData(OperationId operationId, AccountId accountId, DateTime date, decimal value) : base(
        operationId,
        accountId,
        "Replenish",
        $"Replenished bank account balance by {value}",
        date)
    { }
}