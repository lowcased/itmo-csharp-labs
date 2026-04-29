using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Results;

public abstract record CheckBalanceResult : IOperationResult
{
    public record Success(Money Balance) : CheckBalanceResult;

    public record Failure(string Message) : CheckBalanceResult;
}