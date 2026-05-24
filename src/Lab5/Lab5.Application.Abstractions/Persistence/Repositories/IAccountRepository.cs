using Lab5.Application.Abstraction.Persistence.Queries;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Abstraction.Persistence.Repositories;

public interface IAccountRepository
{
    BankAccount Add(BankAccount account);

    void Update(BankAccount account);

    IEnumerable<BankAccount> Query(AccountQuery query);
}