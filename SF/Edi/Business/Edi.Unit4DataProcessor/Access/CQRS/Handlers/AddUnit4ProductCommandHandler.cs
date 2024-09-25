namespace Edi.Unit4DataProcessor.Access.CQRS.Handlers;
internal class AddUnit4ProductCommandHandler : IRequestHandler<AddUnit4ProductCommand, bool>
{
    private readonly IUnit4Repository<DbAlgProductInput> _repository;
    private readonly ILogger<AddUnit4ProductCommandHandler> _logger;

    public AddUnit4ProductCommandHandler(IUnit4Repository<DbAlgProductInput> repository, ILogger<AddUnit4ProductCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(AddUnit4ProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddAsync(request.ProductData, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }

}
