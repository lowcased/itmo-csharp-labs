using Lab5.Domain.History;

namespace Lab5.Application.Contracts.Accounts.Operations;

public static class ShowHistory
{
    public readonly struct Request(Guid sessionId)
    {
        public Guid SessionId { get; } = sessionId;
    }

    public abstract record Response()
    {
        public record Success(IEnumerable<OperationData> Operations) : Response;

        public record Failure(string Message) : Response;
    }
}