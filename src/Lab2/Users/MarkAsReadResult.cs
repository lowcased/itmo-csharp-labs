namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public record MarkAsReadResult
{
    private MarkAsReadResult() { }

    public sealed record class Success : MarkAsReadResult;

    public sealed record class AlreadyRead : MarkAsReadResult;

    public sealed record class NotFound : MarkAsReadResult;
}