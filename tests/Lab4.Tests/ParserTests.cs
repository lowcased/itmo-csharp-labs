using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OutputManager;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void Parser_Should_Create_ConnectCommand()
    {
        // Arrange
        IOutputManager output = new ConsoleOutput();
        var linkFactory = new CommandLinkFactory();
        IParserLink link = linkFactory.Create();
        var parser = new Parser(link);
        string commandStr = "connect /C/Users";
        string[] arguments = commandStr.Split(' ');

        // Act
        ParseResult result = parser.Parse(arguments);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success command)
        {
            Assert.IsType<Connect>(command.Command);
        }
    }

    [Fact]
    public void Parser_Should_Create_DisconnectCommand()
    {
        // Arrange
        IOutputManager output = new ConsoleOutput();
        var linkFactory = new CommandLinkFactory();
        IParserLink link = linkFactory.Create();
        var parser = new Parser(link);
        string commandStr = "disconnect";
        string[] arguments = commandStr.Split(' ');

        // Act
        ParseResult result = parser.Parse(arguments);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success command)
        {
            Assert.IsType<Disconnect>(command.Command);
        }
    }

    [Fact]
    public void Parser_Should_Create_TreeGotoCommand()
    {
        // Arrange
        IOutputManager output = new ConsoleOutput();
        var linkFactory = new CommandLinkFactory();
        IParserLink link = linkFactory.Create();
        var parser = new Parser(link);
        string commandStr = "tree goto /C/Users";
        string[] arguments = commandStr.Split(' ');

        // Act
        ParseResult result = parser.Parse(arguments);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success command)
        {
            Assert.IsType<TreeGoto>(command.Command);
        }
    }

    [Fact]
    public void Parser_Should_Create_FileShowCommand()
    {
        // Arrange
        IOutputManager output = new ConsoleOutput();
        var linkFactory = new CommandLinkFactory();
        IParserLink link = linkFactory.Create();
        var parser = new Parser(link);
        string commandStr = "file show C/Users -m console";
        string[] arguments = commandStr.Split(' ');

        // Act
        ParseResult result = parser.Parse(arguments);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success command)
        {
            Assert.IsType<FileShow>(command.Command);
        }
    }

    [Fact]
    public void Parser_Should_Create_FileMoveCommand()
    {
        // Arrange
        IOutputManager output = new ConsoleOutput();
        var linkFactory = new CommandLinkFactory();
        IParserLink link = linkFactory.Create();
        var parser = new Parser(link);
        string commandStr = "file move /C/Users /C/Users/dev";
        string[] arguments = commandStr.Split(' ');

        // Act
        ParseResult result = parser.Parse(arguments);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success command)
        {
            Assert.IsType<FileMove>(command.Command);
        }
    }
}