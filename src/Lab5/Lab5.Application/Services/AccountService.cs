using Lab5.Application.Abstraction.Persistence;
using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.History;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.History;
using Lab5.Domain.Operations;
using Lab5.Domain.Results;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;
using CheckBalance = Lab5.Application.Contracts.Accounts.Operations.CheckBalance;

namespace Lab5.Application.Services;

internal sealed class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        var sessionId = new SessionId(request.SessionId);
        AdminSession? session = AuthorizeToAdminSession(sessionId);
        if (session == null)
        {
            return new CreateAccount.Response.Failure("Failed to log into the admin session");
        }

        var number = new AccountNumber(request.AccountNumber);
        BankAccount? existingAccount = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithNumber(number)))
            .SingleOrDefault();
        if (existingAccount != null)
        {
            return new CreateAccount.Response.Failure("Account with that number already exists");
        }

        var pinCode = new PinCode(request.PinCode);
        var account = new BankAccount(AccountId.Default, number, pinCode, new OperationHistory(_context.Operations));
        account = _context.Accounts.Add(account);

        return new CreateAccount.Response.Success(account.MapToDto());
    }

    public CheckBalance.Response CheckBalance(CheckBalance.Request request)
    {
        var sessionId = new SessionId(request.SessionId);
        UserSession? session = AuthorizeToUserSession(sessionId);
        if (session == null)
        {
            return new CheckBalance.Response.Failure("Failed to log into the user session");
        }

        BankAccount? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(session.AccountId)))
            .SingleOrDefault();
        if (account == null)
        {
            return new CheckBalance.Response.Failure("Bank account not found");
        }

        IOperation operation = new Domain.Operations.CheckBalance(OperationId.Default);

        IOperationResult result = account.AcceptOperation(operation);
        if (result is CheckBalanceResult.Success success)
        {
            return new CheckBalance.Response.Success(success.Balance.Value);
        }

        if (result is CheckBalanceResult.Failure failure)
        {
            return new CheckBalance.Response.Failure(failure.Message);
        }

        return new CheckBalance.Response.Failure("Unknown error");
    }

    public WithdrawMoney.Response WithdrawMoney(WithdrawMoney.Request request)
    {
        var sessionId = new SessionId(request.SessionId);
        UserSession? session = AuthorizeToUserSession(sessionId);
        if (session == null)
        {
            return new WithdrawMoney.Response.Failure("Failed to log into the user session");
        }

        BankAccount? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(session.AccountId)))
            .SingleOrDefault();
        if (account == null)
        {
            return new WithdrawMoney.Response.Failure("Bank account not found");
        }

        var money = new Money(request.Value);
        IOperation operation = new Withdraw(OperationId.Default, money);

        IOperationResult result = account.AcceptOperation(operation);
        _context.Accounts.Update(account);
        if (result is WithdrawResult.Success)
        {
            return new WithdrawMoney.Response.Success();
        }

        if (result is WithdrawResult.Failure failure)
        {
            return new WithdrawMoney.Response.Failure(failure.Message);
        }

        return new WithdrawMoney.Response.Failure("Unknown error");
    }

    public ReplenishMoney.Response ReplenishMoney(ReplenishMoney.Request request)
    {
        var sessionId = new SessionId(request.SessionId);
        UserSession? session = AuthorizeToUserSession(sessionId);
        if (session == null)
        {
            return new ReplenishMoney.Response.Failure("Failed to log into the user session");
        }

        BankAccount? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(session.AccountId)))
            .SingleOrDefault();
        if (account == null)
        {
            return new ReplenishMoney.Response.Failure("Bank account not found");
        }

        var money = new Money(request.Value);
        IOperation operation = new Replenish(OperationId.Default, money);

        IOperationResult result = account.AcceptOperation(operation);
        _context.Accounts.Update(account);
        if (result is ReplenishResult.Success)
        {
            return new ReplenishMoney.Response.Success();
        }

        if (result is ReplenishResult.Failure failure)
        {
            return new ReplenishMoney.Response.Failure(failure.Message);
        }

        return new ReplenishMoney.Response.Failure($"Unknown error, {result.GetType().Name}");
    }

    public ShowHistory.Response ShowHistory(ShowHistory.Request request)
    {
        var sessionId = new SessionId(request.SessionId);
        UserSession? session = AuthorizeToUserSession(sessionId);
        if (session == null)
        {
            return new ShowHistory.Response.Failure("Failed to log into the user session");
        }

        IEnumerable<OperationData> operations = _context.Operations
            .Query(OperationQuery.Build(builder => builder.WithAccountId(session.AccountId)));

        return new ShowHistory.Response.Success(operations);
    }

    private UserSession? AuthorizeToUserSession(SessionId sessionId)
    {
        UserSession? session = _context.UserSessions
            .Query(SessionQuery.Build(builder => builder.WithId(sessionId)))
            .SingleOrDefault();

        return session;
    }

    private AdminSession? AuthorizeToAdminSession(SessionId sessionId)
    {
        AdminSession? session = _context.AdminSessions
            .Query(SessionQuery.Build(builder => builder.WithId(sessionId)))
            .SingleOrDefault();

        return session;
    }
}