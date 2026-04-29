using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Filters;

public interface IFilter
{
    FilterResult FilterMessage(Message message);
}