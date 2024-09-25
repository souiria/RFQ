namespace Edi.Unit4DataValidator.Access.CQRS.Handlers;
internal class UpdateEdiInvoiceUnit4CommandHandler : IRequestHandler<UpdateEdiInvoiceUnit4Command, bool>
{
    private readonly ISalesEdiRepository<DbEdiInvoiceUnit4> _repository;
    private readonly ILogger<UpdateEdiInvoiceUnit4CommandHandler> _logger;

    public UpdateEdiInvoiceUnit4CommandHandler(ISalesEdiRepository<DbEdiInvoiceUnit4> repository, ILogger<UpdateEdiInvoiceUnit4CommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateEdiInvoiceUnit4Command request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.UpdateRangeAsync(request.EdiInvoiceUnit4, cancellationToken);
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
