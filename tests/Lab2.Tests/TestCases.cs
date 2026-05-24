using Itmo.ObjectOrientedProgramming.Lab2.Addressee;
using Itmo.ObjectOrientedProgramming.Lab2.Archiver;
using Itmo.ObjectOrientedProgramming.Lab2.Filters;
using Itmo.ObjectOrientedProgramming.Lab2.Formatter;
using Itmo.ObjectOrientedProgramming.Lab2.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestCases
{
    [Fact]
    public void UserSendMessage_Should_SaveMessageUnread()
    {
        // Arrange
        string header = "some header";
        string body = "some body";
        ImportanceLevel importanceLevel = ImportanceLevel.Low;
        var message = new Message(header, body, importanceLevel);
        var user = new User();

        // Act
        user.SendMessage(message);

        // Assert
        bool isMessageRead = user.IsMessageRead(message);
        Assert.False(isMessageRead);
    }

    [Fact]
    public void UserMarkAsRead_Should_ChangeMessageReadStatus()
    {
        // Arrange
        string header = "some header";
        string body = "some body";
        ImportanceLevel importanceLevel = ImportanceLevel.Medium;
        var message = new Message(header, body, importanceLevel);
        var user = new User();
        user.SendMessage(message);
        bool isMessageRead1 = user.IsMessageRead(message);

        // Act
        user.MarkAsRead(message);

        // Assert
        bool isMessageRead2 = user.IsMessageRead(message);
        Assert.NotEqual(isMessageRead1, isMessageRead2);
    }

    [Fact]
    public void UserMarkAsRead_Should_Fail_When_MessageIsAlreadyRead()
    {
        // Arrange
        string header = "some header";
        string body = "some body";
        ImportanceLevel importanceLevel = ImportanceLevel.High;
        var message = new Message(header, body, importanceLevel);
        var user = new User();
        user.SendMessage(message);
        user.MarkAsRead(message);

        // Act
        MarkAsReadResult result = user.MarkAsRead(message);

        // Assert
        Assert.IsType<MarkAsReadResult.AlreadyRead>(result);
    }

    [Fact]
    public void FilteredAddresseeSendMessage_Should_FilterMessage()
    {
        // Arrange
        string header = "some header";
        string body = "some body";
        ImportanceLevel importanceLevel = ImportanceLevel.Low;
        var message = new Message(header, body, importanceLevel);
        IAddressee mockAddressee = Substitute.For<IAddressee>();
        var filter = new Filter(ImportanceLevel.High);
        var filteredAddressee = new FilteredAddressee(mockAddressee, filter);

        // Act
        filteredAddressee.SendMessage(message);

        // Assert
        mockAddressee.DidNotReceive().SendMessage(message);
    }

    [Fact]
    public void LoggingAddresseeSendMessage_Should_SaveLog()
    {
        // Arrange
        string header = "some header";
        string body = "some body";
        ImportanceLevel importanceLevel = ImportanceLevel.Low;
        var message = new Message(header, body, importanceLevel);
        var user = new User();
        var userAddressee = new UserAddressee(user);
        ILogger mockLogger = Substitute.For<ILogger>();
        var loggingAddressee = new LoggingAddressee(mockLogger, userAddressee);

        // Act
        loggingAddressee.SendMessage(message);

        // Assert
        mockLogger.Received(1).Log("Message sent");
    }

    [Fact]
    public void FormattingArchiverSaveMessage_Should_WriteHeaderAndBodyUsingFormatter()
    {
        // Arrange
        string header = "some header";
        string body = "some body";
        ImportanceLevel importanceLevel = ImportanceLevel.Low;
        var message = new Message(header, body, importanceLevel);
        IMessageFormatter mockFormatter = Substitute.For<IMessageFormatter>();
        var formattingArchiver = new FormattingArchiver(mockFormatter);

        // Act
        formattingArchiver.SaveMessage(message);

        // Assert
        mockFormatter.Received(1).WriteHeader(header);
        mockFormatter.Received(1).WriteBody(body);
    }

    [Fact]
    public void SendMessage_Should_DeliverMessageOnlyOnceToUser_When_OneAddresseeIsFiltered()
    {
        // Arrange
        string header = "some header";
        string body = "some body";
        ImportanceLevel importanceLevel = ImportanceLevel.Low;
        var message = new Message(header, body, importanceLevel);
        User mockUser = Substitute.For<User>();
        var userAddressee1 = new UserAddressee(mockUser);
        var userAddressee2 = new UserAddressee(mockUser);
        var filter = new Filter(ImportanceLevel.High);
        var filteredAddressee = new FilteredAddressee(userAddressee1, filter);

        // Act
        filteredAddressee.SendMessage(message);
        userAddressee2.SendMessage(message);

        // Assert
        mockUser.Received(1).SendMessage(message);
    }
}