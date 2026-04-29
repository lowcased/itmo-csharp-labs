using Lab5.Application.Contracts.Accounts.Models;

namespace Lab5.Application.Contracts.Accounts.Operations;

public static class CreateAccount
{
    public readonly struct Request(Guid sessionId, string accountNumber, string pinCode)
    {
        public Guid SessionId { get; } = sessionId;

        public string AccountNumber { get; } = accountNumber;

        public string PinCode { get; } = pinCode;
    }

    public abstract record Response
    {
        public record Success(AccountDto Account) : Response;

        public record Failure(string Message) : Response;
    }
}