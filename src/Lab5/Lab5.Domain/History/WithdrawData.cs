using Lab5.Domain.Accounts;
using Lab5.Domain.Operations;

namespace Lab5.Domain.History;

public class WithdrawData : OperationData
{
    public WithdrawData(OperationId operationId, AccountId accountId, DateTime date, decimal value) : base(
        operationId,
        accountId,
        "Withdraw",
        $"Withdrew bank account balance by {value}",
        date)
    { }
}