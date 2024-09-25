namespace Edi.DataProcessor.Engine;
internal class ExternalSalesPriceEngine : IRequestHandler<ExternalSalesPriceRequest, List<ExternalSalesPriceInformationViewDto>>,
    IRequestHandler<FindSalesPriceRequest, List<EdiInvoiceInformationDto>>
{
    private readonly ILogger<ExternalSalesPriceEngine> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public ExternalSalesPriceEngine(ILogger<ExternalSalesPriceEngine> logger, IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<List<ExternalSalesPriceInformationViewDto>> Handle(ExternalSalesPriceRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        var result = await _mediator.Send(new GetHarnessOneSalesPricesQuery(), cancellationToken);
        _logger.LogInformation($"Updating Sales Prices - {result.Count} prices loaded");
        return result;
    }

    public async Task<List<EdiInvoiceInformationDto>> Handle(FindSalesPriceRequest request, CancellationToken cancellationToken)
    {
        // Check for valid prices
        foreach (var invoiceInformation in request.InvoiceInformation.Where(x => x.Status != EdiInvoiceStatus.HeldUp))
        {
            invoiceInformation.Status = EdiInvoiceStatus.MissingPrice;

            var partNumber = request.Parameters.IsUsingPartNumber ? invoiceInformation.PartNumber : invoiceInformation.CustomerPartNumber;
            var salesPrice = Manager.DataProcessor.ExternalSalesPrices
                .FirstOrDefault(x => x.FinanceCode == invoiceInformation.FinanceCode
                            && x.EndDate >= invoiceInformation.DispatchDate.Date
                            && x.StartDate <= invoiceInformation.DispatchDate.Date
                            && x.ProductNumber == partNumber);
            // If price has been found
            if (salesPrice != null)
            {
                if (request.Parameters is { IsUsingH1CustomerOrderNumber: true, IsUsingH1SchedulingAgreement: false })
                    invoiceInformation.CustomerOrderNumber = salesPrice.OrderNumber;
                if (request.Parameters is { IsUsingH1CustomerOrderNumber: true, IsUsingH1SchedulingAgreement: true })
                    invoiceInformation.CustomerOrderNumber = salesPrice.SchedulingAgreement ?? "";
                invoiceInformation.OrderPrice = salesPrice.OrderPrice;
                invoiceInformation.CurrencyCode =
                    salesPrice.CurrencyCode ?? invoiceInformation.CurrencyCode;
                invoiceInformation.IsValidPrice = true;
                invoiceInformation.Status = EdiInvoiceStatus.HeldUp;
                invoiceInformation.TotalInvoicePrice = invoiceInformation.OrderPrice * invoiceInformation.Quantity;
            }
            else
            {
                // If no price has been found, check if 0 price is allowed
                if (!request.Parameters.AllowZeroPrices) continue;
                // Check exceptions table by WMSSiteCode and return part numbers
                var query = new GetZeroPriceExceptionsQuery { WmsSiteCode = invoiceInformation.WMSCustomerCode };
                var results = await _mediator.Send(query, cancellationToken);
                if (!results.Any(
                        x => x.ProductNumber == invoiceInformation.PartNumber || x.ProductNumber == "ALL"))
                    continue;
                invoiceInformation.IsValidPrice = true;
                invoiceInformation.OrderPrice = 0;
                invoiceInformation.Status = EdiInvoiceStatus.HeldUp;
            }
        }

        //await CalculateHeldUpValue(request.InvoiceInformation, cancellationToken);
        await UpdateEdiInvoiceInformationAsync(request.InvoiceInformation, cancellationToken);

        if (request.InvoiceInformation.All(x => x.Status == EdiInvoiceStatus.HeldUp))
            await _publishEndpoint.Publish(new SalesPriceDataUpdated { SalesPriceData = request.InvoiceInformation }, cancellationToken);

        return request.InvoiceInformation;
    }

    private async Task<bool> UpdateEdiInvoiceInformationAsync(List<EdiInvoiceInformationDto> invoiceInformation, CancellationToken cancellationToken)
    {
        try
        {
            return await _mediator.Send(new UpdateEdiInvoiceInformationCommand(_mapper.Map<List<DbEdiInvoiceInformation>>(invoiceInformation)), cancellationToken);
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

    private async Task CalculateHeldUpValue(List<EdiInvoiceInformationDto> invoiceInformation,
        CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        var totalInvoicePrice = invoiceInformation
            .Where(m => m.Status == EdiInvoiceStatus.HeldUp)
            .Aggregate(0, (double m, EdiInvoiceInformationDto n) => m += n.Quantity * n.OrderPrice);
        foreach (var item in invoiceInformation) { item.TotalInvoicePrice = totalInvoicePrice; }
    }
}
