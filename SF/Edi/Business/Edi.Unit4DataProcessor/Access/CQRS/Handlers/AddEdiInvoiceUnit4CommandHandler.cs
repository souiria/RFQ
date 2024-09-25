namespace Edi.Unit4DataProcessor.Access.CQRS.Handlers;
internal class AddEdiInvoiceUnit4CommandHandler : IRequestHandler<AddEdiInvoiceUnit4Command, bool>
{
    private readonly ISalesEdiRepository<DbEdiInvoiceUnit4> _repository;
    private readonly ILogger<AddEdiInvoiceUnit4CommandHandler> _logger;

    public AddEdiInvoiceUnit4CommandHandler(ISalesEdiRepository<DbEdiInvoiceUnit4> repository, ILogger<AddEdiInvoiceUnit4CommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(AddEdiInvoiceUnit4Command request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddRangeAsync(request.EdiInvoiceUnit4, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            Console.WriteLine(ex);
            return false;
        }

    }
}
