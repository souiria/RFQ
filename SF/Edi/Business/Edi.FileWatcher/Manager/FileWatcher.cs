using Edi.Common.MassTransit;

namespace Edi.FileWatcher.Manager;

/// <summary>
/// An instance of this class is created for each service instance by the Service Fabric runtime.
/// </summary>
public class FileWatcher : StatelessService
{
    private readonly IMediator _mediator;
    private readonly IBusControl _bus;

    public FileWatcher(StatelessServiceContext context, IMediator mediator, IBusControl bus)
        : base(context)
    {
        _mediator = mediator;
        _bus = bus;
    }

    /// <summary>
    /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
    /// </summary>
    /// <returns>A collection of listeners.</returns>
    protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
    {
        return new[]
        {
            new ServiceInstanceListener(_ => new MassTransitListener(_bus), "MassTransit-SalesEdiFileWatcher")
        };
    }

    /// <summary>
    /// This is the main entry point for your service instance.
    /// </summary>
    /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
    protected override async Task RunAsync(CancellationToken cancellationToken)
    {
        var timer = Convert.ToInt32(Environment.GetEnvironmentVariable("DROPBOX_TIMER") ?? "30");

        long iterations = 0;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _mediator.Send(new CheckForFilesRequest(), cancellationToken);
            ServiceEventSource.Current.ServiceMessage(Context, "Check for files-{0}", ++iterations);

            await Task.Delay(TimeSpan.FromSeconds(timer), cancellationToken);
        }
    }
}