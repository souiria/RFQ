namespace Edi.Common.Interfaces;
public interface IEmailHelper
{
    Task SendEdiEmailAsync(EmailContentDto emailContent, CancellationToken token);
}
