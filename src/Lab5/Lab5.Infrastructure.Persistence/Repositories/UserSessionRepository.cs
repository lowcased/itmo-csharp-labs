using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Application.Abstraction.Persistence.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

internal sealed class UserSessionRepository : IUserSessionRepository
{
    private readonly Dictionary<SessionId, UserSession> _values = [];

    public UserSession Add(UserSession session)
    {
        SessionId id = GenerateId();
        session = new UserSession(
            id,
            session.AccountId);

        _values.Add(session.Id, session);

        return session;
    }

    public IEnumerable<UserSession> Query(SessionQuery query)
    {
        return _values.Values
            .Where(x => query.Ids is [] || query.Ids.Contains(x.Id));
    }

    private SessionId GenerateId()
    {
        SessionId id;
        do
        {
            id = new SessionId(Guid.NewGuid());
        }
        while (_values.ContainsKey(id));

        return id;
    }
}