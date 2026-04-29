namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public interface ICommand
{
    CommandResult Execute(Context context);
}