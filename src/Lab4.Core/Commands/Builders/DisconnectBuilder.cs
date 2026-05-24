using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public class DisconnectBuilder : ICommandBuilder
{
    public CommandBuilderResult Build()
    {
        return new CommandBuilderResult.Success(new Disconnect());
    }
}