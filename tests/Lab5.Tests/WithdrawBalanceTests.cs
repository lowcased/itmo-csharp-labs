using Lab5.Application.Abstraction.Persistence;
using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Application.Abstraction.Persistence.Repositories;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Services;
using Lab5.Domain.Accounts;
using Lab5.Domain.History;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class WithdrawBalanceTests
{
    [Fact]
    public void BankAccount_ShouldBeUpdated_AfterWithdraw_WhenEnoughFunds()
    {
        // Arrange
        IAdminSessionRepository adminRepository = Substitute.For<IAdminSessionRepository>();
        IUserSessionRepository userRepository = Substitute.For<IUserSessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IOperationRepository operationRepository = Substitute.For<IOperationRepository>();

        IPersistenceContext context = Substitute.For<IPersistenceContext>();
        context.AdminSessions.Returns(adminRepository);
        context.UserSessions.Returns(userRepository);
        context.Accounts.Returns(accountRepository);
        context.Operations.Returns(operationRepository);

        var accountService = new AccountService(context);
        var userSession = new UserSession(default, default);
        userRepository
            .Query(Arg.Any<SessionQuery>())
            .Returns([userSession]);
        var account = new BankAccount(default, default, new PinCode("0000"), Substitute.For<IOperationHistory>());
        account.Replenish(new Money(100));
        accountRepository
            .Query(Arg.Any<AccountQuery>())
            .Returns([account]);
        var request = new WithdrawMoney.Request(Guid.Empty, 30);

        // Act
        accountService.WithdrawMoney(request);

        // Assert
        Assert.Equal(new Money(70), account.Balance);
        accountRepository.Received().Update(account);
    }

    [Fact]
    public void Withdraw_ShouldReturnError_WhenNotEnoughFunds()
    {
        // Arrange
        IAdminSessionRepository adminRepository = Substitute.For<IAdminSessionRepository>();
        IUserSessionRepository userRepository = Substitute.For<IUserSessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IOperationRepository operationRepository = Substitute.For<IOperationRepository>();

        IPersistenceContext context = Substitute.For<IPersistenceContext>();
        context.AdminSessions.Returns(adminRepository);
        context.UserSessions.Returns(userRepository);
        context.Accounts.Returns(accountRepository);
        context.Operations.Returns(operationRepository);

        var accountService = new AccountService(context);
        var userSession = new UserSession(default, default);
        userRepository
            .Query(Arg.Any<SessionQuery>())
            .Returns([userSession]);
        var account = new BankAccount(default, default, new PinCode("0000"), Substitute.For<IOperationHistory>());
        account.Replenish(new Money(10));
        accountRepository
            .Query(Arg.Any<AccountQuery>())
            .Returns([account]);
        var request = new WithdrawMoney.Request(Guid.Empty, 30);

        // Act
        WithdrawMoney.Response response = accountService.WithdrawMoney(request);

        // Assert
        Assert.IsType<WithdrawMoney.Response.Failure>(response);
        if (response is WithdrawMoney.Response.Failure failure)
        {
            Assert.Equal("Insufficient funds on balance", failure.Message);
        }
    }
}