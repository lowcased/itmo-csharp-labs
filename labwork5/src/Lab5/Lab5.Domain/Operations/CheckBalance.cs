using Lab5.Domain.Accounts;
using Lab5.Domain.History;
using Lab5.Domain.Results;

namespace Lab5.Domain.Operations;

public class CheckBalance : IOperation
{
    public CheckBalance(OperationId id)
    {
        Id = id;
    }

    public OperationId Id { get; }

    public OperationData? Data { get; private set; }

    public IOperationResult Execute(BankAccount account)
    {
        Data = new CheckBalanceData(Id, account.Id, DateTime.Now);
        return new CheckBalanceResult.Success(account.Balance);
    }
}