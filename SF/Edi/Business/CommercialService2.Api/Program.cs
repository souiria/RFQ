using CommercialService2.Api;

try
{
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
    var appName = Environment.GetEnvironmentVariable("Fabric_ApplicationName");

    // Check if the host is Service Fabric, if not, use local
    if (appName == null)
    {
        var app = CommercialService2HostBuilder.CreateApp();

        //app.UseHttpsRedirection();
        Log.Information("Api Service has been hosted locally");
        app.Run();
    }
    else
    {
        // The ServiceManifest.XML file defines one or more service type names.
        // Registering a service maps a service type name to a .NET type.
        // When Service Fabric creates an instance of this service type,
        // an instance of the class is created in this host process.

        ServiceRuntime.RegisterServiceAsync("CommercialService2.ApiType",
            context => new Api(context)).GetAwaiter().GetResult();

        ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(Api).Name);

        // Prevents this host process from terminating so services keeps running. 
        Thread.Sleep(Timeout.Infinite);
    }
}
catch (Exception e)
{
    Log.Fatal(e, "Unhandled exception");
    ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
    throw;
}
finally
{
    await Log.CloseAndFlushAsync();
}