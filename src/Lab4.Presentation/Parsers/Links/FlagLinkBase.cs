namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Links;

public abstract class FlagLinkBase : ParserLinkBase
{
    protected FlagLinkBase()
    {
        First = this;
    }

    protected FlagLinkBase First { get; private set; }

    public void SetFirstFlag(FlagLinkBase flag)
    {
        First = flag;
    }
}