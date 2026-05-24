using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public ActionResult<AccountDto> CreateBankAccount([FromBody] CreateAccountRequest createAccountRequest)
    {
        var request = new CreateAccount.Request(
            createAccountRequest.SessionId,
            createAccountRequest.Number,
            createAccountRequest.PinCode);
        CreateAccount.Response response = _accountService.CreateAccount(request);

        return response switch
        {
            CreateAccount.Response.Success success => Ok(success),
            CreateAccount.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("operations/CheckBalance")]
    public ActionResult<decimal> CheckAccountBalance(Guid sessionId)
    {
        var request = new CheckBalance.Request(sessionId);
        CheckBalance.Response response = _accountService.CheckBalance(request);

        return response switch
        {
            CheckBalance.Response.Success success => Ok(success),
            CheckBalance.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("operations/Replenish")]
    public ActionResult<decimal> ReplenishBalance([FromBody] ReplenishBalanceRequest replenishBalanceRequest)
    {
        var request = new ReplenishMoney.Request(replenishBalanceRequest.SessionId, replenishBalanceRequest.Value);
        ReplenishMoney.Response response = _accountService.ReplenishMoney(request);

        return response switch
        {
            ReplenishMoney.Response.Success success => Ok(success),
            ReplenishMoney.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("operations/Withdraw")]
    public ActionResult<decimal> WithdrawBalance([FromBody] WithdrawBalanceRequest withdrawBalanceRequest)
    {
        var request = new WithdrawMoney.Request(withdrawBalanceRequest.SessionId, withdrawBalanceRequest.Value);
        WithdrawMoney.Response response = _accountService.WithdrawMoney(request);

        return response switch
        {
            WithdrawMoney.Response.Success success => Ok(success),
            WithdrawMoney.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("operations/ShowHistory")]
    public ActionResult<decimal> ShowOperationHistory(Guid sessionId)
    {
        var request = new ShowHistory.Request(sessionId);
        ShowHistory.Response response = _accountService.ShowHistory(request);

        return response switch
        {
            ShowHistory.Response.Success success => Ok(success),
            ShowHistory.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}