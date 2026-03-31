namespace Rfq
{
    public static class HostBuilder
    {

        public static WebApplication CreateApp(
               WebApplicationBuilder? builder = null,
               string? pathBase = "/",
               string[]? args = null)
                    {

            args ??= Array.Empty<string>();
             builder ??= WebApplication.CreateBuilder(args);

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

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });

            #endregion

            #endregion

            #region App

            WebApplication app = builder.Build();
            ILogger logger = app.Services.GetRequiredService<ILoggerFactory>()
                .CreateLogger("Rfq.Startup");

            logger.GenericLogInformation("III RFQ Service starting up - SEQ test message");

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            if (!string.IsNullOrEmpty(pathBase) && pathBase != "/")
            {
                app.UsePathBase(pathBase);
            }

            app.UseRouting();
            app.UseCors();
            GrpcWebOptions grpcWebOptions = new GrpcWebOptions();
            grpcWebOptions.DefaultEnabled = true;
            app.UseGrpcWeb(grpcWebOptions);
  
            app.MapGrpcService<RfqGrpcService>()
             .EnableGrpcWeb();
   
            app.MapGet("/", () => "RFQ AccessService running with HTTPS and gRPC-W");
            #endregion

            return app;
        }
    }
}
