using Lab5.Domain.History;
using Lab5.Domain.Operations;
using Lab5.Domain.Results;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public class BankAccount
{
    public BankAccount(AccountId id, AccountNumber number, PinCode pinCode, IOperationHistory history)
    {
        Id = id;
        Number = number;
        PinCode = pinCode;
        History = history;
        Balance = new Money(0);
    }

    public AccountId Id { get; }

    public AccountNumber Number { get; }

    public PinCode PinCode { get; }

    public Money Balance { get; private set; }

    public IOperationHistory History { get; }

    public IOperationResult AcceptOperation(IOperation operation)
    {
        IOperationResult result = operation.Execute(this);
        if (operation.Data != null)
        {
            History.Save(operation.Data);
        }

        return result;
    }

    public WithdrawResult Withdraw(Money value)
    {
        if (Balance.Value < value.Value)
        {
            return new WithdrawResult.Failure("Insufficient funds on balance");
        }

        Balance -= value;
        return new WithdrawResult.Success();
    }

    public ReplenishResult Replenish(Money value)
    {
        Balance += value;
        return new ReplenishResult.Success();
    }
}