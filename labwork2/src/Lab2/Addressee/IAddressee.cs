using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressee;

public interface IAddressee
{
    void SendMessage(Message message);
}