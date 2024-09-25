namespace Edi.Unit4DataProcessor.Access.CQRS.Handlers;
internal class GetUnit4ProductMasterQueryHandler : IRequestHandler<GetUnit4ProductMasterQuery, List<Unit4ProductDto>>
{
    private readonly IUnit4ReadRepository<DbMinAlgArticle> _repository;
    private readonly IMapper _mapper;

    public GetUnit4ProductMasterQueryHandler(IUnit4ReadRepository<DbMinAlgArticle> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<Unit4ProductDto>> Handle(GetUnit4ProductMasterQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _repository.ListAsync(new GetUnit4ProductMasterReadOnlySpec(), cancellationToken);
            return _mapper.Map<List<Unit4ProductDto>>(results);
        }
        catch (AutoMapperMappingException ex)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new SafeExceptionConverter()); //Add a converter.
            throw new Exception(JsonConvert.SerializeObject(ex, settings));
        }
        catch (Exception ex)
        {
            // TODO: Log error
            throw;
        }
    }
}
