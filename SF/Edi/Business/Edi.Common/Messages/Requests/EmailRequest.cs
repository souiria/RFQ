namespace Edi.Common.Messages.Requests;
public class EmailRequest : RequestBase
{
    public EmailDto? EmailContent { get; set; }
    public CommercialEmailRequestType RequestType { get; set; }
}

public enum CommercialEmailRequestType
{
    CheckForHeartBeat,
    CreateEmail
}
