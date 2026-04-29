using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Filters;

public class Filter : IFilter
{
    private readonly ImportanceLevel _minImportanceLevel;

    public Filter(ImportanceLevel minImportanceLevel = ImportanceLevel.Low)
    {
        _minImportanceLevel = minImportanceLevel;
    }

    public FilterResult FilterMessage(Message message)
    {
        if (message.Importance < _minImportanceLevel)
        {
            return new FilterResult.Failed();
        }

        return new FilterResult.Passed(message);
    }
}