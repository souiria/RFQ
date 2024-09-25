namespace Edi.DataProcessor.Manager.Consumers;
public class DispatchDataUploadConsumer : IConsumer<DispatchDataInserted>
{
    readonly ILogger<DispatchDataUploadConsumer> _logger;
    private readonly IMediator _mediator;

    public DispatchDataUploadConsumer(ILogger<DispatchDataUploadConsumer> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<DispatchDataInserted> context)
    {
        var dispatch = context.Message.DispatchData.First();
        _logger.LogInformation($"Dispatch upload data request received for {dispatch.DispatchNumber} sent on {dispatch.DispatchDate} on account {dispatch.FinanceCode}");

        var parameters = DataProcessor.EdiCustomerParameters.First(x => x.FinanceCode == dispatch.FinanceCode);

        var results = await _mediator.Send(new FindSalesPriceRequest { InvoiceInformation = context.Message.DispatchData, Parameters = parameters });



    }
}

