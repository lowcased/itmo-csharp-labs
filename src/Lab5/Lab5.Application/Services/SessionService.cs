using Lab5.Application.Abstraction.Persistence;
using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

internal sealed class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;

    public SessionService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAdminSession.Response Create(CreateAdminSession.Request request)
    {
        string adminPassword = "isu465446";
        if (request.Password != adminPassword)
        {
            return new CreateAdminSession.Response.Failure("Incorrect password");
        }

        var adminSession = new AdminSession(SessionId.Default);
        adminSession = _context.AdminSessions.Add(adminSession);

        return new CreateAdminSession.Response.Success(adminSession.MapToDto());
    }

    public CreateUserSession.Response Create(CreateUserSession.Request request)
    {
        var number = new AccountNumber(request.AccountNumber);
        BankAccount? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithNumber(number)))
            .SingleOrDefault();
        if (account == null)
        {
            return new CreateUserSession.Response.Failure("Account not found");
        }

        var pinCode = new PinCode(request.PinCode);
        if (account.PinCode != pinCode)
        {
            return new CreateUserSession.Response.Failure("Incorrect pin code");
        }

        var userSession = new UserSession(SessionId.Default, account.Id);
        userSession = _context.UserSessions.Add(userSession);

        return new CreateUserSession.Response.Success(userSession.MapToDto());
    }
}