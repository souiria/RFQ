namespace Edi.Unit4DataProcessor.Access.CQRS.Handlers;
internal class DeleteEdiInvoiceInformationCommandHandler : IRequestHandler<DeleteEdiInvoiceInformationCommand, bool>
{
    private readonly ISalesEdiRepository<DbEdiInvoiceInformation> _repository;
    private readonly ILogger<DeleteEdiInvoiceInformationCommandHandler> _logger;

    public DeleteEdiInvoiceInformationCommandHandler(ISalesEdiRepository<DbEdiInvoiceInformation> repository, ILogger<DeleteEdiInvoiceInformationCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(DeleteEdiInvoiceInformationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteRangeAsync(request.EdiInvoiceInformation, cancellationToken);
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
