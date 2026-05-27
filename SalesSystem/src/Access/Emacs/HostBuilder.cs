namespace Emacs
{
    public static class HostBuilder
    {
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {
            builder ??= WebApplication.CreateBuilder(args);
            string dir = Directory.GetCurrentDirectory();
            builder.Configuration
                .SetBasePath(dir)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

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
            builder.Services.AddSingleton<IEMACSAccessService, EMACSAccessService>();
            builder.Services.AddHostedService<DataImportSchedulerService>();

            #endregion

            #endregion

            #region App

            WebApplication app = builder.Build();

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
            app.MapGrpcService<EMACSGrpcService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            #endregion

            return app;
        }
    }
}
