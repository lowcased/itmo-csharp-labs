using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Mapping;

public static class SessionMappingExtensions
{
    public static AdminSessionDto MapToDto(this AdminSession adminSession)
    {
        return new AdminSessionDto(adminSession.Id.Value);
    }

    public static UserSessionDto MapToDto(this UserSession userSession)
    {
        return new UserSessionDto(userSession.Id.Value);
    }
}