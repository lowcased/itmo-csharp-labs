namespace Lab5.Domain.Sessions;

public class AdminSession
{
    public AdminSession(SessionId id)
    {
        Id = id;
    }

    public SessionId Id { get; }
}