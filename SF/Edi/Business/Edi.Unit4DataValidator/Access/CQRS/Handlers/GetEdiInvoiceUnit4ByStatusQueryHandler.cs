namespace Edi.Unit4DataValidator.Access.CQRS.Handlers;
internal class GetEdiInvoiceUnit4ByStatusQueryHandler : IRequestHandler<GetEdiInvoiceUnit4ByStatusQuery, List<EdiInvoiceInformationDto>>
{
    private readonly ISalesEdiReadRepository<DbEdiInvoiceUnit4> _repository;
    private readonly IMapper _mapper;

    public GetEdiInvoiceUnit4ByStatusQueryHandler(ISalesEdiReadRepository<DbEdiInvoiceUnit4> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<EdiInvoiceInformationDto>> Handle(GetEdiInvoiceUnit4ByStatusQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _repository.ListAsync(new GetEdiInvoiceUnit4ByStatusReadOnlySpec(request.EdiInvoiceStatus), cancellationToken);
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
            // TODO: Log error
            throw;
        }
    }
}
