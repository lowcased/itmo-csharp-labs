using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Domain.History;

namespace Lab5.Application.Abstraction.Persistence.Repositories;

public interface IOperationRepository
{
    OperationData Add(OperationData operation);

    IEnumerable<OperationData> Query(OperationQuery query);
}