namespace Edi.Common.Exceptions;
public class CopyToSafeException(Exception oldException) : Exception
{
    public override string? Source
    {
        get => oldException.Source;
        set => oldException.Source = value;
    }

    public override string? HelpLink
    {
        get => oldException.HelpLink;
        set => oldException.HelpLink = value;
    }

    public override IDictionary Data => oldException.Data;

    public override string Message => oldException.Message;

    public override string? StackTrace => oldException.StackTrace;
}
