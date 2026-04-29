namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

public class Disconnect : ICommand
{
    public CommandResult Execute(Context context)
    {
        context.Disconnect();
        return new CommandResult.Success();
    }
}