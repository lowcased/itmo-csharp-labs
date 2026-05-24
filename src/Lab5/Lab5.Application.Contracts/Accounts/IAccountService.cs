using Lab5.Application.Contracts.Accounts.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    CreateAccount.Response CreateAccount(CreateAccount.Request request);

    CheckBalance.Response CheckBalance(CheckBalance.Request request);

    WithdrawMoney.Response WithdrawMoney(WithdrawMoney.Request request);

    ReplenishMoney.Response ReplenishMoney(ReplenishMoney.Request request);

    ShowHistory.Response ShowHistory(ShowHistory.Request request);
}