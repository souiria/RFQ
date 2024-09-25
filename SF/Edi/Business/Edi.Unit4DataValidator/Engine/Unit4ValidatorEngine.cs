namespace Edi.Unit4DataValidator.Engine;
internal class Unit4ValidatorEngine : IRequestHandler<Unit4InvoiceValidatorRequest>
{
    private readonly ILogger<Unit4ValidatorEngine> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public Unit4ValidatorEngine(ILogger<Unit4ValidatorEngine> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task Handle(Unit4InvoiceValidatorRequest request, CancellationToken cancellationToken)
    {
        // Get Customer Parameter Data
        var customerParameters = await _mediator.Send(new GetEdiCustomerParametersQuery(), cancellationToken);
        
        // Read data from EdiInvoiceUnit4 with status SentToUnit4
        var query = new GetEdiInvoiceUnit4ByStatusQuery { EdiInvoiceStatus = EdiInvoiceStatus.SentToUnit4 };
        var sentItems = _mapper.Map<IEnumerable<EdiInvoiceInformationDto>>(await _mediator.Send(query, cancellationToken));
        var sentItemsGrouped = sentItems.GroupBy(x => x.DispatchNumber);

        foreach (var sentItem in sentItemsGrouped)
        {
            try
            {
                var dispatch = sentItem.FirstOrDefault();
                var parameters = customerParameters.First(x => x.FinanceCode == dispatch.FinanceCode);

                var dispatchNumber = parameters.IsUsingCustomerDispatchNumber
                    ? dispatch.CustomerDispatchNumber
                    : dispatch.DispatchNumber;

                // Fetch items that match dispatch/account/date from asoheader/asodetail
                var unit4Query = new GetUnit4SalesOrdersQuery
                {
                    FinanceCode = parameters.FinanceCode,
                    Client = parameters.Unit4Client,
                    DispatchNumber = dispatchNumber,
                    DispatchDate = dispatch.DispatchDate
                };
                // Read data from Unit4 invoices
                var unit4Invoices = await _mediator.Send(unit4Query, cancellationToken);
                // Perform comparison
                foreach (var item in sentItem)
                {
                    var partNumber = parameters.IsUsingPartNumber ? item.PartNumber : item.CustomerPartNumber;
                    if (unit4Invoices.All(x => x.ProductNumber != partNumber)) continue;
                    item.Status = EdiInvoiceStatus.ConfirmedInUnit4;
                    item.IsAgressoTransferred = true;
                }

                if (sentItem.Any(x => x.Status != EdiInvoiceStatus.ConfirmedInUnit4)) continue;
                var data = _mapper.Map<List<DbEdiInvoiceUnit4>>(sentItem.ToList());
                await _mediator.Send(new UpdateEdiInvoiceUnit4Command(data), cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}
