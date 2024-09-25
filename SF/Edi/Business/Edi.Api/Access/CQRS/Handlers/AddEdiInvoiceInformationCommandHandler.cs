namespace Edi.Api.Access.CQRS.Handlers;
internal class AddEdiInvoiceInformationCommandHandler : IRequestHandler<AddEdiInvoiceInformationCommand, bool>
{
    private readonly ISalesEdiRepository<DbEdiInvoiceInformation> _repository;
    private readonly ILogger<AddEdiInvoiceInformationCommandHandler> _logger;

    public AddEdiInvoiceInformationCommandHandler(ISalesEdiRepository<DbEdiInvoiceInformation> repository, ILogger<AddEdiInvoiceInformationCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(AddEdiInvoiceInformationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddRangeAsync(request.Data, cancellationToken);
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
