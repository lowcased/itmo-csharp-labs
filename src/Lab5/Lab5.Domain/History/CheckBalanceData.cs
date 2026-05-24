using Lab5.Domain.Accounts;
using Lab5.Domain.Operations;

namespace Lab5.Domain.History;

public class CheckBalanceData : OperationData
{
    public CheckBalanceData(OperationId operationId, AccountId accountId, DateTime date) : base(
        operationId,
        accountId,
        "Check balance",
        "Checked bank account balance",
        date)
    { }
}