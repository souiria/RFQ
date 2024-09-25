using Edi.Unit4DataProcessor.Access.CQRS.Commands;

namespace Edi.Unit4DataProcessor.Access.CQRS.Handlers;
internal class AddDispatchToUnit4CommandHandler : IRequestHandler<AddDispatchToUnit4Command, bool>
{
    private readonly IUnit4Repository<DbAlgBatchInput> _repository;
    private readonly ILogger<AddDispatchToUnit4CommandHandler> _logger;

    public AddDispatchToUnit4CommandHandler(IUnit4Repository<DbAlgBatchInput> repository, ILogger<AddDispatchToUnit4CommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(AddDispatchToUnit4Command request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddRangeAsync(request.Unit4AlgBatchInput, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}

