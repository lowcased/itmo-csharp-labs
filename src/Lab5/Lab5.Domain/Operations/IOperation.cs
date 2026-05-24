using Lab5.Domain.Accounts;
using Lab5.Domain.History;
using Lab5.Domain.Results;

namespace Lab5.Domain.Operations;

public interface IOperation
{
    OperationId Id { get; }

    OperationData? Data { get; }

    IOperationResult Execute(BankAccount account);
}