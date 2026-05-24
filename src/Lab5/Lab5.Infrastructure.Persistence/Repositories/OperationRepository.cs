using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Application.Abstraction.Persistence.Repositories;
using Lab5.Domain.History;
using Lab5.Domain.Operations;

namespace Lab5.Infrastructure.Persistence.Repositories;

internal sealed class OperationRepository : IOperationRepository
{
    private readonly Dictionary<OperationId, OperationData> _values = [];

    public OperationData Add(OperationData operation)
    {
        OperationId id = GenerateId();
        operation = new OperationData(
            id,
            operation.AccountId,
            operation.Name,
            operation.Description,
            operation.Date);

        _values.Add(operation.OperationId, operation);

        return operation;
    }

    public IEnumerable<OperationData> Query(OperationQuery query)
    {
        return _values.Values
            .Where(x => query.OperationIds is [] || query.OperationIds.Contains(x.OperationId))
            .Where(x => query.AccountIds is [] || query.AccountIds.Contains(x.AccountId));
    }

    private OperationId GenerateId()
    {
        OperationId id;
        do
        {
            id = new OperationId(Guid.NewGuid());
        }
        while (_values.ContainsKey(id));

        return id;
    }
}