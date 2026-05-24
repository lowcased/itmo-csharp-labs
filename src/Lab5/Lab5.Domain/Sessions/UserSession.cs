using Lab5.Domain.Accounts;

namespace Lab5.Domain.Sessions;

public class UserSession
{
    public UserSession(SessionId id, AccountId accountId)
    {
        Id = id;
        AccountId = accountId;
    }

    public SessionId Id { get; }

    public AccountId AccountId { get; }
}