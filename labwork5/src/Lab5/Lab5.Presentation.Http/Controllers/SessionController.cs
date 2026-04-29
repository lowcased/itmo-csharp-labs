using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("admin")]
    public ActionResult<UserSessionDto> CreateAdminSession(string password)
    {
        var request = new CreateAdminSession.Request(password);
        CreateAdminSession.Response response = _sessionService.Create(request);

        return response switch
        {
            CreateAdminSession.Response.Success success => Ok(success),
            CreateAdminSession.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("user")]
    public ActionResult<UserSessionDto> CreateUserSession(CreateUserSessionRequest createUserSessionRequest)
    {
        var request = new CreateUserSession.Request(
            createUserSessionRequest.Number,
            createUserSessionRequest.PinCode);
        CreateUserSession.Response response = _sessionService.Create(request);

        return response switch
        {
            CreateUserSession.Response.Success success => Ok(success),
            CreateUserSession.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}