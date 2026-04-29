using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models;

public class CreateUserSessionRequest
{
    [NotNull]
    [Length(20, 20)]
    public string? Number { get; set; }

    [NotNull]
    [Length(4, 4)]
    public string? PinCode { get; set; }
}