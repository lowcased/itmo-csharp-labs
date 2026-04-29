namespace Lab5.Domain.Results;

public abstract record WithdrawResult : IOperationResult
{
    public record Success() : WithdrawResult;

    public record Failure(string Message) : WithdrawResult;
}