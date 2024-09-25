namespace Edi.Api.Access.CQRS.Handlers;
internal class GetCustomerParameterQueryHandler : IRequestHandler<GetCustomerParameterQuery, List<EdiCustomerParameterDto>>
{
    private readonly ISalesEdiReadRepository<DbEdiCustomerParameter> _repository;
    private readonly IMapper _mapper;

    public GetCustomerParameterQueryHandler(ISalesEdiReadRepository<DbEdiCustomerParameter> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<EdiCustomerParameterDto>> Handle(GetCustomerParameterQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(request.FinanceCode))
            {
                var results = await _repository.ListAsync(cancellationToken);
                return _mapper.Map<List<EdiCustomerParameterDto>>(results);
            }
            else
            {
                var customerParameters = await _repository.ListAsync(new GetCustomerParameterByFinanceCodeReadOnlySpec(request.FinanceCode), cancellationToken);
                return _mapper.Map<List<EdiCustomerParameterDto>>(customerParameters);
            }
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
