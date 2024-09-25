namespace Edi.Unit4DataProcessor.Access.CQRS.Handlers;
internal class GetUnit4InputProductsQueryHandler : IRequestHandler<GetUnit4InputProductsQuery, int>
{
    private readonly IUnit4ReadRepository<DbAlgProductInput> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetUnit4InputProductsQueryHandler> _logger;

    public GetUnit4InputProductsQueryHandler(IUnit4ReadRepository<DbAlgProductInput> repository, IMapper mapper, ILogger<GetUnit4InputProductsQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(GetUnit4InputProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _repository.CountAsync(new GetUnit4InputProductsReadOnlySpec(request.PartNumber, request.Client), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
