using Lab5.Application.Abstraction.Persistence.Repositories;

namespace Lab5.Application.Abstraction.Persistence;

public interface IPersistenceContext
{
    IAdminSessionRepository AdminSessions { get; }

    IUserSessionRepository UserSessions { get; }

    IAccountRepository Accounts { get; }

    IOperationRepository Operations { get; }
}