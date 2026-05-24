using Lab5.Application.Abstraction.Persistence;
using Lab5.Application.Abstraction.Persistence.Repositories;

namespace Lab5.Infrastructure.Persistence;

internal sealed class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(
        IAdminSessionRepository adminSessions,
        IUserSessionRepository userSessions,
        IAccountRepository accounts,
        IOperationRepository operations)
    {
        AdminSessions = adminSessions;
        UserSessions = userSessions;
        Accounts = accounts;
        Operations = operations;
    }

    public IAdminSessionRepository AdminSessions { get; }

    public IUserSessionRepository UserSessions { get; }

    public IAccountRepository Accounts { get; }

    public IOperationRepository Operations { get; }
}