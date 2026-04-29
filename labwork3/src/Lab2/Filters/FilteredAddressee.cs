using Itmo.ObjectOrientedProgramming.Lab2.Addressee;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Filters;

public class FilteredAddressee : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly IFilter _filter;

    public FilteredAddressee(IAddressee addressee, IFilter filter)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
        _filter = filter ?? throw new ArgumentNullException(nameof(filter));
    }

    public void SendMessage(Message message)
    {
        FilterResult filterResult = _filter.FilterMessage(message);
        if (filterResult is FilterResult.Passed passed)
        {
            _addressee.SendMessage(passed.Message);
        }
    }
}