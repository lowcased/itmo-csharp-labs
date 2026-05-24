using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Sessions.Operations;

public static class CreateAdminSession
{
    public readonly struct Request(string password)
    {
        public string Password { get; } = password;
    }

    public abstract record Response
    {
        public sealed record Success(AdminSessionDto AdminSession) : Response;

        public sealed record Failure(string Message) : Response;
    }
}