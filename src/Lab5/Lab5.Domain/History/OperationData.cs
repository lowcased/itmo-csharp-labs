using Lab5.Domain.Accounts;
using Lab5.Domain.Operations;

namespace Lab5.Domain.History;

public class OperationData
{
    public OperationData(OperationId operationId, AccountId accountId, string name, string description, DateTime date)
    {
        OperationId = operationId;
        AccountId = accountId;
        Name = name;
        Description = description;
        Date = date;
    }

    public OperationId OperationId { get; }

    public AccountId AccountId { get; }

    public string Name { get; }

    public string Description { get; }

    public DateTime Date { get; }
}