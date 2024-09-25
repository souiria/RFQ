namespace Edi.DataProcessor.Manager;

/// <summary>
/// An instance of this class is created for each service instance by the Service Fabric runtime.
/// </summary>
public class DataProcessor : StatelessService
{
    private readonly IBusControl _bus;
    private readonly IMediator _mediator;
    public static List<ExternalSalesPriceInformationViewDto>? ExternalSalesPrices;
    public static List<EdiCustomerParameterDto>? EdiCustomerParameters;

    public DataProcessor(StatelessServiceContext context, IBusControl bus, IMediator mediator)
        : base(context)
    {
        _bus = bus;
        _mediator = mediator;
    }

    /// <summary>
    /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
    /// </summary>
    /// <returns>A collection of listeners.</returns>
    protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
    {
        return new[]
        {
            new ServiceInstanceListener(_ => new MassTransitListener(_bus), "MassTransit-SalesEdiDataProcessor")
        };
    }

    /// <summary>
    /// This is the main entry point for your service instance.
    /// </summary>
    /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
    protected override async Task RunAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            EdiCustomerParameters = await _mediator.Send(new EdiCustomerParameterRequest(), cancellationToken);
            ExternalSalesPrices = await _mediator.Send(new ExternalSalesPriceRequest(), cancellationToken);
            ServiceEventSource.Current.ServiceMessage(Context, $"Updating Sales Prices - {ExternalSalesPrices.Count} prices loaded");

            await Task.Delay(TimeSpan.FromMinutes(60), cancellationToken);
        }
    }
}