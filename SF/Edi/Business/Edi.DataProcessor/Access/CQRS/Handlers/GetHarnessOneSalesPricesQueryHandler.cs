namespace Edi.DataProcessor.Access.CQRS.Handlers;
internal class GetHarnessOneSalesPricesQueryHandler : IRequestHandler<GetHarnessOneSalesPricesQuery, List<ExternalSalesPriceInformationViewDto>>
{
    private readonly IQuotationSystemReadRepository<DbExternalSalesPriceInformationView> _repository;
    private readonly IMapper _mapper;

    public GetHarnessOneSalesPricesQueryHandler(IQuotationSystemReadRepository<DbExternalSalesPriceInformationView> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ExternalSalesPriceInformationViewDto>> Handle(GetHarnessOneSalesPricesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _repository.ListAsync(new GetHarnessOneSalesPricesReadOnlySpec(), cancellationToken);
            return _mapper.Map<List<ExternalSalesPriceInformationViewDto>>(results);
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
