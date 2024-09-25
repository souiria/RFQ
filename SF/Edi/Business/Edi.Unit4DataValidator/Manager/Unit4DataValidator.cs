namespace Edi.Unit4DataValidator.Manager;

/// <summary>
/// An instance of this class is created for each service instance by the Service Fabric runtime.
/// </summary>
public class Unit4DataValidator : StatelessService
{
    private readonly IBusControl _bus;
    private readonly IMediator _mediator;

    public Unit4DataValidator(StatelessServiceContext context, IBusControl bus, IMediator mediator)
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
            new ServiceInstanceListener(_ => new MassTransitListener(_bus), "MassTransit-SalesEdiUnit4DataValidator")
        };
    }

    /// <summary>
    /// This is the main entry point for your service instance.
    /// </summary>
    /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
    protected override async Task RunAsync(CancellationToken cancellationToken)
    {
        var timer = Convert.ToInt32(Environment.GetEnvironmentVariable("UNIT4_VALIDATOR_TIMER") ?? "15");

        long iterations = 0;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ServiceEventSource.Current.ServiceMessage(Context, $"Validating Unit4 Invoice Data.");
            await _mediator.Send(new Unit4InvoiceValidatorRequest(), cancellationToken);
            await Task.Delay(TimeSpan.FromMinutes(timer), cancellationToken);
        }
    }
}