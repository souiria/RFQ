namespace Edi.Unit4DataProcessor.Manager.Consumers;
public class SalesPriceDataUpdatedConsumer : IConsumer<SalesPriceDataUpdated>
{
    readonly ILogger<SalesPriceDataUpdatedConsumer> _logger;
    private readonly IMediator _mediator;

    public SalesPriceDataUpdatedConsumer(ILogger<SalesPriceDataUpdatedConsumer> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<SalesPriceDataUpdated> context)
    {
        /*
           Push data into Unit4 batch input table
           Save data into EdiInvoiceUnit4 table with status SentToUnit4
           Remove data from EdiInvoiceProcessing table

           Finished.
         */
        var dispatch = context.Message.SalesPriceData.First();
        var customerParameters = Unit4DataProcessor.EdiCustomerParameters.First(x => x.FinanceCode == dispatch.FinanceCode);
        _logger.LogInformation($"Sales Price Data updated message received for dispatch {dispatch.DispatchNumber} sent on {dispatch.DispatchDate} on account {dispatch.FinanceCode}");

        // Check for valid product number - if one doesn't exist, create it in Unit4
        var productValidatedResults = await _mediator.Send(new ValidateProductRequest{SalesPriceData = context.Message.SalesPriceData, CustomerParameters = customerParameters});
        // Check if dispatch already exists in Unit4
        var dispatchValidatedResults = await _mediator.Send(new ValidateUnit4DispatchRequest { SalesPriceData = productValidatedResults, CustomerParameters = customerParameters });
        //await ValidateProducts(context.Message.SalesPriceData, customerParameters);
        //var parameters = DataProcessor.EdiCustomerParameters.First(x => x.FinanceCode == dispatch.FinanceCode);

        //var results = await _mediator.Send(new FindSalesPriceRequest { InvoiceInformation = context.Message.DispatchData, Parameters = parameters });

    }
}
