using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstraction.Persistence.Repositories;

public interface IAdminSessionRepository
{
    AdminSession Add(AdminSession session);

    IEnumerable<AdminSession> Query(SessionQuery query);
}