
namespace Edi.DataProcessor.Access.CQRS.Handlers;
internal class GetEdiCustomerParametersQueryHandler : IRequestHandler<GetEdiCustomerParametersQuery, List<EdiCustomerParameterDto>>
{
    private readonly ISalesEdiReadRepository<DbEdiCustomerParameter> _repository;
    private readonly IMapper _mapper;

    public GetEdiCustomerParametersQueryHandler(ISalesEdiReadRepository<DbEdiCustomerParameter> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<EdiCustomerParameterDto>> Handle(GetEdiCustomerParametersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _repository.ListAsync(new GetEdiCustomerParametersReadOnlySpec(), cancellationToken);
            return _mapper.Map<List<EdiCustomerParameterDto>>(results);
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
