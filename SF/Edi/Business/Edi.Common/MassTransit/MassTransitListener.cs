namespace Edi.Common.MassTransit;
public class MassTransitListener : ICommunicationListener
{
    private readonly IBusControl _busControl;

    public MassTransitListener(IBusControl busControl)
    {
        _busControl = busControl;
    }

    public async Task<string> OpenAsync(CancellationToken cancellationToken)
    {
        Trace.WriteLine("Initialize");
        await _busControl.StartAsync(cancellationToken).ConfigureAwait(false);

        Trace.WriteLine($"Connection to {_busControl.Address}");

        return _busControl.Address.AbsoluteUri;
    }

    public async Task CloseAsync(CancellationToken cancellationToken)
    {
        Trace.WriteLine("Close");

        await _busControl.StopAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    public void Abort()
    {
        Trace.WriteLine("Abort");

        _busControl.Stop();
    }
}
