namespace Lab5.Application.Contracts.Accounts.Operations;

public static class ReplenishMoney
{
    public struct Request(Guid sessionId, decimal value)
    {
        public Guid SessionId { get; } = sessionId;

        public decimal Value { get; } = value;
    }

    public abstract record Response
    {
        public record Success() : Response;

        public record Failure(string Message) : Response;
    }
}