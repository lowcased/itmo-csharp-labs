using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver;

public interface IArchiver
{
    void SaveMessage(Message message);
}