
namespace Edi.DataProcessor.Access.CQRS.Handlers;
internal class GetZeroPriceExceptionsQueryHandler : IRequestHandler<GetZeroPriceExceptionsQuery, List<ZeroPriceExceptionsDto>>
{
    private readonly ISalesEdiReadRepository<DbZeroPriceExceptions> _repository;
    private readonly IMapper _mapper;

    public GetZeroPriceExceptionsQueryHandler(ISalesEdiReadRepository<DbZeroPriceExceptions> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ZeroPriceExceptionsDto>> Handle(GetZeroPriceExceptionsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _repository.ListAsync(new GetZeroPriceExceptionsReadOnlySpec(request.WmsSiteCode), cancellationToken);
            return _mapper.Map<List<ZeroPriceExceptionsDto>>(results);
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
