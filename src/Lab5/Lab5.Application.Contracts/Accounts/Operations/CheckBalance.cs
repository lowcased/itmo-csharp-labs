namespace Lab5.Application.Contracts.Accounts.Operations;

public static class CheckBalance
{
    public readonly struct Request(Guid sessionId)
    {
        public Guid SessionId { get; } = sessionId;
    }

    public abstract record Response()
    {
        public record Success(decimal Balance) : Response;

        public record Failure(string Message) : Response;
    }
}