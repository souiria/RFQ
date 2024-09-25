using Autofac;
using Autofac.Integration.ServiceFabric;
using Serilog;
using System.Threading;

namespace Edi.FileWatcher;

internal static class Program
{
    /// <summary>
    /// This is the entry point of the service host process.
    /// </summary>
    private static void Main()
    {
        try
        {
            #region Initial Logging

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
                .Enrich.WithProperty("Application", "Example")
                .WriteTo.Console(Formatters.CreateConsoleTextFormatter(theme: TemplateTheme.Code))
                .WriteTo.Seq(
                    Environment.GetEnvironmentVariable("SEQ_URL") ?? "http://localhost:5341",
                    apiKey: Environment.GetEnvironmentVariable("SEQ_API_KEY"))
                .CreateLogger();
            Log.Information("Starting up");

            #endregion

            var appName = Environment.GetEnvironmentVariable("Fabric_ApplicationName");

            // Check if the host is Service Fabric, if not, use local
            if (appName == null)
            {
                var builder = EdiHostBuilder.CreateBuilder();
                Log.Information("Edi File Watcher has started locally");
                using (builder.Build())
                {
                    var timer = Convert.ToInt32(Environment.GetEnvironmentVariable("DROPBOX_TIMER") ?? "30");

                    long iterations = 0;

                    while (true)
                    {
                        Log.Debug("Checking for Files.");
                        Task.Delay(TimeSpan.FromSeconds(timer));
                    }
                }
            }
            else
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                // Start with the trusty old container builder.
                var builder = EdiHostBuilder.CreateBuilder();

                // Register any regular dependencies in EdiHostBuilder.

                // Register the Autofac magic for Service Fabric support.
                builder.RegisterServiceFabricSupport();

                // Register the stateless service.
                builder.RegisterStatelessService<Manager.FileWatcher>("Edi.FileWatcherType");

                using (builder.Build())
                {
                    ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, nameof(Manager.FileWatcher));

                    // Prevents this host process from terminating so services keep running.
                    Thread.Sleep(Timeout.Infinite);
                }
            }
        }
        catch (Exception e)
        {
            ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
            throw;
        }
    }
}