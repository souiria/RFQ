namespace Edi.FileWatcher.Manager;

public static class EdiHostBuilder
{
    public static ContainerBuilder CreateBuilder()
    {
        // Start with creating a standard Service Collection.
        var collection = new ServiceCollection();

        #region Application Insights

        var aiOptions = new ApplicationInsightsServiceOptions
        {
            EnableAdaptiveSampling = false,
            EnableQuickPulseMetricStream = false,
            ConnectionString = Environment.GetEnvironmentVariable("APPINSIGHTS_CONNECTION")
        };

        collection.AddSingleton<ITelemetryInitializer>((serviceProvider) => FabricTelemetryInitializerExtension.CreateFabricTelemetryInitializer(serviceProvider.GetService<ServiceContext>()));
        collection.AddSingleton<ITelemetryInitializer>(new CloudRoleNameTelemetryInitializer("COMMERCIAL.Edi.FileWatcher"));
        collection.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) => { module.EnableSqlCommandTextInstrumentation = true; });
        collection.AddApplicationInsightsTelemetryWorkerService(aiOptions);

        #endregion

        // Create an autofac factory.
        var factory = new AutofacServiceProviderFactory();
        // Then the builder using the factory.
        var builder = factory.CreateBuilder(collection);

        #region Builder

        builder.RegisterModule(new DataAccessModule());
        builder.RegisterModule(new LoggingModule());
        builder.RegisterModule(new MassTransitModule());
        builder.RegisterModule(new MediatrModule(typeof(Program).Assembly, typeof(MediatrModule).Assembly));
        builder.RegisterModule(new AutoMapperModule(typeof(Program).Assembly));

        #endregion
        
        return builder;
    }
}
