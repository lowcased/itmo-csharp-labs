using Itmo.ObjectOrientedProgramming.Lab2.Addressee;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Logger;

public class LoggingAddressee : IAddressee
{
    private readonly ILogger _logger;

    private readonly IAddressee _addressee;

    public LoggingAddressee(ILogger logger, IAddressee addressee)
    {
        _logger = logger;
        _addressee = addressee;
    }

    public void SendMessage(Message message)
    {
        try
        {
            _addressee.SendMessage(message);
            _logger.Log("Message sent");
        }
        catch (Exception ex)
        {
            _logger.Log($"Message delivery failed: {ex.GetType().Name} - {ex.Message}");
            throw;
        }
    }
}