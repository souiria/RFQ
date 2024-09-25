namespace CommercialService2.Api.Common.Exceptions;
public class CopyToSafeException : Exception
{
    private readonly Exception _oldException;

    public CopyToSafeException(Exception oldException)
    {
        _oldException = oldException;
    }

    public override string Source
    {
        get => _oldException.Source;
        set => _oldException.Source = value;
    }

    public override string HelpLink
    {
        get => _oldException.HelpLink;
        set => _oldException.HelpLink = value;
    }

    public override IDictionary Data => _oldException.Data;

    public override string Message => _oldException.Message;

    public override string StackTrace => _oldException.StackTrace;
}
