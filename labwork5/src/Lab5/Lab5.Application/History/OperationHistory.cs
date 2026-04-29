using Lab5.Application.Abstraction.Persistence.Repositories;
using Lab5.Domain.History;

namespace Lab5.Application.History;

public class OperationHistory : IOperationHistory
{
    private readonly IOperationRepository _repository;

    public OperationHistory(IOperationRepository repository)
    {
        _repository = repository;
    }

    public void Save(OperationData operation)
    {
        _repository.Add(operation);
    }
}