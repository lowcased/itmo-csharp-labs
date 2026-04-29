namespace Lab5.Domain.History;

public interface IOperationHistory
{
    void Save(OperationData operation);
}