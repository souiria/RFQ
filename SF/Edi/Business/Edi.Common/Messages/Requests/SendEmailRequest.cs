namespace Edi.Common.Messages.Requests;

public class SendEmailRequest : IRequest<bool>
{
    public required EmailContentDto EmailContent { get; set; }
}
