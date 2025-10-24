namespace RfqModule
{
    public static class HostBuilder
    {
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {

            builder ??= WebApplication.CreateBuilder(args);

            #region Builder

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            builder.Services.AddEndpointsApiExplorer();

            // *********************************************************************
            // Add additional generic services here (anything ServiceFabric specific
            // should go in Api.cs CreateServiceInstanceListeners method)
            // *********************************************************************

            #region Additional Services
            builder.AddServiceDefaults();
            builder.Logging.AddSeq();
            builder.Services.AddGrpc(opt =>
            {
                opt.EnableDetailedErrors = true;
                opt.MaxReceiveMessageSize = int.MaxValue;
                opt.MaxSendMessageSize = int.MaxValue;
            });
            builder.Services.AddSingleton<IRfqManagerService, RfqManagerService>();
            builder.Services.AddGrpcClient<Master.Master.MasterClient>(o =>
            {
                o.Address = new Uri("https://localhost:7101");
            });
            builder.Services.AddGrpcClient<Rfq.Rfq.RfqClient>(o =>
            {
                o.Address = new Uri("https://localhost:7116");
            });
            builder.Services.AddInfrastructure();

            #endregion

            #endregion

            #region App

            WebApplication app = builder.Build();

            // Log that the RfqManager service has started
            ILogger<WebApplication> logger = app.Services.GetRequiredService<ILogger<WebApplication>>();
#pragma warning disable CA1848 // Use the LoggerMessage delegates
            logger.LogInformation("RfqManager service started successfully at {Timestamp}. Environment: {Environment}, Service: {ServiceName}", 
                DateTime.UtcNow, 
                app.Environment.EnvironmentName, 
                "RfqManager");
#pragma warning restore CA1848 // Use the LoggerMessage delegates

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            GrpcWebOptions grpcWebOptions = new GrpcWebOptions();
            grpcWebOptions.DefaultEnabled = true;
            app.UseGrpcWeb(grpcWebOptions);
            app.MapGrpcService<RfqGrpcService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            

            #endregion

            return app;
        }
    }
}
