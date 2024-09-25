namespace Edi.DataProcessor.Access.CQRS.Handlers;
internal class UpdateEdiInvoiceInformationHandler : IRequestHandler<UpdateEdiInvoiceInformationCommand, bool>
{
    private readonly ISalesEdiRepository<DbEdiInvoiceInformation> _repository;
    private readonly ILogger<UpdateEdiInvoiceInformationHandler> _logger;

    public UpdateEdiInvoiceInformationHandler(ISalesEdiRepository<DbEdiInvoiceInformation> repository, ILogger<UpdateEdiInvoiceInformationHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateEdiInvoiceInformationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.UpdateRangeAsync(request.EdiInvoiceInformation, cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            Console.WriteLine(e);
            return false;
        }
    }
}
