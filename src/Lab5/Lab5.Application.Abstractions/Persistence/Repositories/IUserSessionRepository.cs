using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstraction.Persistence.Repositories;

public interface IUserSessionRepository
{
    UserSession Add(UserSession session);

    IEnumerable<UserSession> Query(SessionQuery query);
}