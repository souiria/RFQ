namespace Edi.Common.Email;

public class EmailHandler : IRequestHandler<SendEmailRequest, bool>
{
    private readonly ILogger<EmailHandler> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly string _ediEmailRecipient;
    private readonly IBusControl _busControl;
    private TelemetryClient _telemetry;

    public EmailHandler(ILogger<EmailHandler> logger, IMediator mediator, IMapper mapper, TelemetryClient telemetry, IBusControl busControl)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
        _telemetry = telemetry;
        _busControl = busControl;
        var emailAddress = Environment.GetEnvironmentVariable("EDI_EMAIL_RECIPIENT") ?? "anthony.woods@sews-e.com";
        _ediEmailRecipient = $"Commercial Edi Errors:{emailAddress}";
    }

    public async Task<bool> Handle(SendEmailRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        try
        {
            switch (request.EmailContent.EmailType)
            {
                case EdiInvoiceEmailType.AlreadyProcessing:
                    await SendAlreadyProcessingEmail(request.EmailContent, cancellationToken);
                    break;
                case EdiInvoiceEmailType.UnsupportedFileExtension:
                    await SendUnsupportedFileExtensionEmail(request.EmailContent, cancellationToken);
                    break;
                case EdiInvoiceEmailType.FileNameAlreadyUploaded:
                    await SendFileNameAlreadyUploadedEmail(request.EmailContent, cancellationToken);
                    break;
                case EdiInvoiceEmailType.ErrorReadingFileData:
                    await SendErrorReadingFileDataEmail(request.EmailContent, cancellationToken);
                    break;
                case EdiInvoiceEmailType.DuplicatedData:
                    await SendDuplicatedDataEmail(request.EmailContent, cancellationToken);
                    break;
                case EdiInvoiceEmailType.ErrorAddingProductToUnit4:
                    await SendErrorAddingProductToUnit4Email(request.EmailContent, cancellationToken);
                    break;
                case EdiInvoiceEmailType.ErrorAddingInvoiceToUnit4:
                    await SendErrorAddingInvoiceToUnit4Email(request.EmailContent, cancellationToken);
                    break;
                case EdiInvoiceEmailType.InvalidColumnCount:
                    await SendErrorInvalidColumnCount(request.EmailContent, cancellationToken);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            _logger.LogError(ex, ex.Message);
            Console.WriteLine(ex);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            Console.WriteLine(ex);
            throw;
        }
    }

    private async Task<EmailDto> CreateBaseEmail(CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        return new EmailDto
        {
            Attachments = null,
            Attempts = 0,
            Bcc = null,
            Body = "",
            Cc = null,
            Module = ApplicationModule.EDI,
            Sent = false,
            Subject = "",
            To = _ediEmailRecipient
        };
    }

    private async Task SendAlreadyProcessingEmail(EmailContentDto emailContent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var emailDto = await CreateBaseEmail(cancellationToken);
        emailDto.Subject = $"FILE: {emailContent.Filename} NOT PROCESSED";
        emailDto.Body = @$"
            <div>An error has been detected with the file:<b>{emailContent.Filename}</b></div>
            <div>&nbsp;</div>
            <div>File with same name is already being processed</div>
            <div>The file has been moved to the ERROR directory</div>";

        emailDto.HashId = HashCode.Combine(emailDto.Subject, emailDto.Module, emailDto.To, emailDto.Body, emailContent.Filename, emailContent.Exception);
        await SendEmailAsync(emailDto, cancellationToken);
    }

    private async Task SendUnsupportedFileExtensionEmail(EmailContentDto emailContent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var emailDto = await CreateBaseEmail(cancellationToken);
        emailDto.Subject = $"FILE: {emailContent.Filename} NOT PROCESSED";
        emailDto.Body = @$"
            <div>An error has been detected with the file:<b>{emailContent.Filename}</b></div>
            <div>&nbsp;</div>
            <div>An unsupported file extension was found.</div>
            <div>The file has been moved to the ERROR directory</div>";

        emailDto.HashId = HashCode.Combine(emailDto.Subject, emailDto.Module, emailDto.To, emailDto.Body);
        await SendEmailAsync(emailDto, cancellationToken);

    }

    private async Task SendFileNameAlreadyUploadedEmail(EmailContentDto emailContent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var emailDto = await CreateBaseEmail(cancellationToken);
        emailDto.Subject = $"FILE: {emailContent.Filename} NOT PROCESSED";
        emailDto.Body = @$"
            <div>An error has been detected with the file: <br /><b>{emailContent.Filename}</b></div>
            <div>&nbsp;</div>
            <div>The file name already exists in the database.</div>
            <div>The file has been moved to the ERROR directory</div>";

        emailDto.HashId = HashCode.Combine(emailDto.Subject, emailDto.Module, emailDto.To, emailDto.Body, emailContent.Filename, emailContent.Exception);
        await SendEmailAsync(emailDto, cancellationToken);

    }

    private async Task SendErrorReadingFileDataEmail(EmailContentDto emailContent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var emailDto = await CreateBaseEmail(cancellationToken);
        emailDto.Subject = $"ERROR DURING {emailContent.Filename} PROCESSING";
        emailDto.Body = @$"
            <div>The following error has occurred during the reading of the data in the file:<b>{emailContent.Filename}</b></div>
            <div><b>{emailContent.Exception?.Message}</b></div>
            <div>&nbsp;</div>
            <div>Please correct this information and try again</div>
            <div>The file has been moved to the ERROR directory</div>";

        emailDto.HashId = HashCode.Combine(emailDto.Subject, emailDto.Module, emailDto.To, emailDto.Body, emailContent.Filename, emailContent.Exception);
        await SendEmailAsync(emailDto, cancellationToken);

    }

    private async Task SendDuplicatedDataEmail(EmailContentDto emailContent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var emailDto = await CreateBaseEmail(cancellationToken);
        emailDto.Subject = $"DUPLICATE DATA FOUND IN {emailContent.Filename}";
        emailDto.Body = @$"
            <div>The following error has occurred during the reading of the data in the file:<b>{emailContent.Filename}</b></div>
            <div>The data for the values <b>{emailContent.DispatchNumber}</b> - <b>{emailContent.DispatchDate}</b> have already been processed under a different file</div>
            <div>&nbsp;</div>
            <div>Please use the Duplicate Items screen inside the H1 system to decide what action needs to be taken.</div>
            <div>Please correct this information and try again</div>";

        emailDto.HashId = HashCode.Combine(emailDto.Subject, emailDto.Module, emailDto.To, emailDto.Body, emailContent.Filename, emailContent.Exception);
        await SendEmailAsync(emailDto, cancellationToken);

    }

    private async Task SendErrorAddingProductToUnit4Email(EmailContentDto emailContent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var emailDto = await CreateBaseEmail(cancellationToken);
        emailDto.Subject = "UNIT4 PRODUCT UPLOAD ERROR";
        emailDto.Body = @$"
            <div>The following error occurred while attempting to load:<b>{emailContent.PartNumber}</b> into Unit4 algproductinput</div> 
            <div><b>{emailContent.Exception?.Message}</b></div>
            <div>&nbsp;</div>
            <div>Please resolve this issue and try again</div>";

        emailDto.HashId = HashCode.Combine(emailDto.Subject, emailDto.Module, emailDto.To, emailDto.Body, emailContent.Filename, emailContent.Exception);
        await SendEmailAsync(emailDto, cancellationToken);

    }

    private async Task SendErrorAddingInvoiceToUnit4Email(EmailContentDto emailContent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var emailDto = await CreateBaseEmail(cancellationToken);
        emailDto.Subject = "UNIT4 BATCH INPUT UPLOAD ERROR";
        emailDto.Body = @$"
            <div>The following error occurred while attempting to load:<b>{emailContent.DispatchNumber}</b> into Unit4 algbatchinput</div>
            <div><b>{emailContent.Exception?.Message}</b></div>
            <div>&nbsp;</div>
            <div>Please resolve this issue and try again</div>";

        emailDto.HashId = HashCode.Combine(emailDto.Subject, emailDto.Module, emailDto.To, emailDto.Body, emailContent.Filename, emailContent.Exception);
        await SendEmailAsync(emailDto, cancellationToken);

    }

    private async Task SendErrorInvalidColumnCount(EmailContentDto emailContent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var emailDto = await CreateBaseEmail(cancellationToken);
        emailDto.Subject = "INVALID FILE ERROR";
        emailDto.Body = @$"
            <div>The following error occurred while attempting to load:<b>{emailContent.Filename}</b> </div>
            <div><b>{emailContent.Exception?.Message}</b></div>
            <div>&nbsp;</div>
            <div>Please resolve this issue and try again</div>";

        emailDto.HashId = HashCode.Combine(emailDto.Subject, emailDto.Module, emailDto.To, emailDto.Body, emailContent.Filename, emailContent.Exception);
        await SendEmailAsync(emailDto, cancellationToken);

    }

    private async Task SendEmailAsync(EmailDto emailDto, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            _telemetry.TrackEvent("Send request over MessageBus (RabbitMQ)");
            _logger.LogInformation($"Attempting to send EMAIL over the BUS. Subject:-{emailDto.Subject} ***  {_busControl.Address}");

            await _busControl.Publish(new EmailRequest { RequestType = CommercialEmailRequestType.CreateEmail, EmailContent = emailDto }, cancellationToken);

            await Task.Delay(0, cancellationToken);
            
        }
        catch (OperationCanceledException OCE)
        {
            // Not a genuine error, continue as normal
        }
        catch (Exception e)
        {
            _telemetry.TrackException(e);
            _logger.LogError(e, e.Message);
            //throw;
        }
        finally
        {
            //_telemetry.StopOperation(operation);
            _telemetry.TrackEvent("Email was sent");
        }

    }
}
