using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Application.Abstraction.Persistence.Repositories;
using Lab5.Domain.Accounts;

namespace Lab5.Infrastructure.Persistence.Repositories;

internal sealed class AccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountId, BankAccount> _values = [];

    public BankAccount Add(BankAccount account)
    {
        AccountId id = GenerateId();
        account = new BankAccount(
            id,
            account.Number,
            account.PinCode,
            account.History);

        _values.Add(account.Id, account);

        return account;
    }

    public void Update(BankAccount account)
    {
        _values[account.Id] = account;
    }

    public IEnumerable<BankAccount> Query(AccountQuery query)
    {
        return _values.Values
            .Where(x => query.Ids is [] || query.Ids.Contains(x.Id))
            .Where(x => query.Numbers is [] || query.Numbers.Contains(x.Number));
    }

    private AccountId GenerateId()
    {
        AccountId id;
        do
        {
            id = new AccountId(Guid.NewGuid());
        }
        while (_values.ContainsKey(id));

        return id;
    }
}