namespace Edi.Unit4DataValidator.Access.CQRS.Handlers;
internal class GetUnit4SalesOrdersQueryHandler : IRequestHandler<GetUnit4SalesOrdersQuery, List<Unit4SalesOrdersViewDto>>
{
    private readonly IUnit4ReadRepository<DbUnit4SalesOrdersView> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetUnit4SalesOrdersQueryHandler> _logger;

    public GetUnit4SalesOrdersQueryHandler(IUnit4ReadRepository<DbUnit4SalesOrdersView> repository, IMapper mapper, ILogger<GetUnit4SalesOrdersQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<Unit4SalesOrdersViewDto>> Handle(GetUnit4SalesOrdersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _repository.ListAsync(new GetUnit4SalesOrdersReadOnlySpec(request.FinanceCode, request.Client, request.DispatchNumber, request.DispatchDate), cancellationToken);
            return _mapper.Map<List<Unit4SalesOrdersViewDto>>(results);
        }
        catch (AutoMapperMappingException ex)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new SafeExceptionConverter()); //Add a converter.
            throw new Exception(JsonConvert.SerializeObject(ex, settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
