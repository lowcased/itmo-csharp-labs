using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Application.Abstraction.Persistence.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

internal sealed class AdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<SessionId, AdminSession> _values = [];

    public AdminSession Add(AdminSession session)
    {
        SessionId id = GenerateId();
        session = new AdminSession(id);

        _values.Add(session.Id, session);

        return session;
    }

    public IEnumerable<AdminSession> Query(SessionQuery query)
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