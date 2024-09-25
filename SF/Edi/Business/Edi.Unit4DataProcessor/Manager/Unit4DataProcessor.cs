namespace Edi.Unit4DataProcessor.Manager;

/// <summary>
/// An instance of this class is created for each service instance by the Service Fabric runtime.
/// </summary>
public class Unit4DataProcessor : StatelessService
{
    private readonly IBusControl _bus;
    private readonly IMediator _mediator;
    public static List<Unit4ProductDto>? Unit4Products;
    public static List<EdiCustomerParameterDto>? EdiCustomerParameters;

    public Unit4DataProcessor(StatelessServiceContext context, IBusControl bus, IMediator mediator)
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
            new ServiceInstanceListener(_ => new MassTransitListener(_bus), "MassTransit-SalesEdiUnit4DataProcessor")
        };
    }

    /// <summary>
    /// This is the main entry point for your service instance.
    /// </summary>
    /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
    protected override async Task RunAsync(CancellationToken cancellationToken)
    {
        var timer = Convert.ToInt32(Environment.GetEnvironmentVariable("UNIT4_PRODUCT_MASTER_TIMER") ?? "10");

        long iterations = 0;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            EdiCustomerParameters = await _mediator.Send(new EdiCustomerParameterRequest(), cancellationToken);
            Unit4Products = await _mediator.Send(new GetUnit4ProductMasterQuery(), cancellationToken);
            ServiceEventSource.Current.ServiceMessage(Context, $"Updating Unit4 Product Data - {Unit4Products.Count} prices loaded");

            await Task.Delay(TimeSpan.FromMinutes(timer), cancellationToken);
        }
    }
}