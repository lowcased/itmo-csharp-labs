using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Mapping;

public static class AccountMappingExtensions
{
    public static AccountDto MapToDto(this BankAccount bankAccount)
    {
        return new AccountDto(bankAccount.Id.Value);
    }
}