using Lab5.Application.Contracts.Sessions.Operations;

namespace Lab5.Application.Contracts.Sessions;

public interface ISessionService
{
    CreateAdminSession.Response Create(CreateAdminSession.Request request);

    CreateUserSession.Response Create(CreateUserSession.Request request);
}