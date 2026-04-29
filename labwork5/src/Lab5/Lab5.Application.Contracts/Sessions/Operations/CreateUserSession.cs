using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Sessions.Operations;

public class CreateUserSession
{
    public readonly struct Request(string accountNumber, string pinCode)
    {
        public string AccountNumber { get; } = accountNumber;

        public string PinCode { get; } = pinCode;
    }

    public abstract record Response
    {
        public sealed record Success(UserSessionDto UserSession) : Response;

        public sealed record Failure(string Message) : Response;
    }
}