namespace Lab5.Domain.Results;

public abstract record ReplenishResult : IOperationResult
{
    public record Success() : ReplenishResult;

    public record Failure(string Message) : ReplenishResult;
}