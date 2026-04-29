using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models;

public class WithdrawBalanceRequest
{
    public Guid SessionId { get; set; }

    [Range(0, double.MaxValue, MinimumIsExclusive = true)]
    public decimal Value { get; set; }
}