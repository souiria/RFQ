namespace Edi.Api.Access.CQRS.Handlers;
internal class GetEdiInvoiceInformationQueryHandler : IRequestHandler<GetEdiInvoiceInformationQuery, List<EdiInvoiceInformationDto>>
{
    private readonly ISalesEdiReadRepository<DbEdiInvoiceInformation> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetEdiInvoiceInformationQueryHandler> _logger;

    public GetEdiInvoiceInformationQueryHandler(ISalesEdiReadRepository<DbEdiInvoiceInformation> repository, IMapper mapper, ILogger<GetEdiInvoiceInformationQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<EdiInvoiceInformationDto>> Handle(GetEdiInvoiceInformationQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _repository.ListAsync(new GetEdiInvoiceInformationReadOnlySpec(), cancellationToken);
            return _mapper.Map<List<EdiInvoiceInformationDto>>(results);
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
