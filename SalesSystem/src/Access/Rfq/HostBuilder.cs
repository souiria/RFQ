namespace Rfq
{
    public static class HostBuilder
    {
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {
            string dir = Directory.GetCurrentDirectory();
        
            builder ??= WebApplication.CreateBuilder(args);
            string version = typeof(HostBuilder).Assembly.GetName().Version?.ToString() ?? "unknown";
            IConfigurationSection conf = builder.Configuration.GetSection("Logging");
            builder.Configuration
                .SetBasePath(dir)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            builder.Logging.ClearProviders();
            builder.Logging.AddConfiguration(conf);
            #region Builder
            #region Kestrel
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = 64 * 1024 * 1024; // 256 MB
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);
                options.Limits.MinResponseDataRate = null;
                options.Limits.MinRequestBodyDataRate = null;
            });
            #endregion

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
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddSingleton<IRfqAccessService, RfqAccessService>();
            builder.Services.AddHostedService<DataImportSchedulerService>();

            #endregion

            #endregion

            #region App

            WebApplication app = builder.Build();
            ILogger logger = app.Services.GetRequiredService<ILoggerFactory>()
                .CreateLogger("Rfq.Startup");

            logger.GenericLogInformation($"III RFQ Access Layer Service version {version} starting up - SEQ test message");
            // what database are we connected to?
            using (IServiceScope scope = app.Services.CreateScope())
            {
                RfqDbContext dbContext = scope.ServiceProvider.GetRequiredService<RfqDbContext>();
                string? connectionString = dbContext.Database.GetConnectionString();
                string? databaseName = dbContext.Database.GetDbConnection().Database;
                string? dataSource = dbContext.Database.GetDbConnection().DataSource;
                logger.GenericLogInformation($"III RFQ Access Layer Service {version}  connected to database: '{databaseName}' on server: '{dataSource}' | Full connection: '{connectionString}'");
            }

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
