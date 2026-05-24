using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OutputManager;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public static class Program
{
    public static void Main(string[] args)
    {
        var linkFactory = new CommandLinkFactory();
        IParserLink link = linkFactory.Create();
        IOutputManager output = new ConsoleOutput();
        var parser = new Parser(link);
        var context = new Context(output);
        while (true)
        {
            string? commandStr = Console.ReadLine();
            if (commandStr == null)
            {
                continue;
            }

            string[] arguments = commandStr.Split(' ');
            ParseResult result = parser.Parse(arguments);
            if (result is ParseResult.Success command)
            {
                CommandResult commandResult = command.Command.Execute(context);
                if (commandResult is CommandResult.Fail fail)
                {
                    Console.WriteLine(fail.Message);
                }
            }
        }
    }
}