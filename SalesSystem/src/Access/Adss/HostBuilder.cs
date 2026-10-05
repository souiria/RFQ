namespace Adss
{
    public static class HostBuilder
    {
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {

            string dir = Directory.GetCurrentDirectory();

            builder ??= WebApplication.CreateBuilder(args);
            IConfigurationSection conf = builder.Configuration.GetSection("Logging");
            builder.Configuration
                .SetBasePath(dir)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            builder.Logging.ClearProviders();
            builder.Logging.AddConfiguration(conf);
            builder.Logging.AddSeq();
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
            builder.Services.AddSingleton<IAdssService, AdssService>();
            IConfigurationSection adssSection = builder.Configuration.GetSection("Adss");
            builder.Services.Configure<AdssSettings>(adssSection);
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
            app.MapGrpcService<AdssGrpcService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

    
            app.MapGet("/adss/part-image/{partNumber}", async (
                    string partNumber,
                    IAdssService svc,
                    CancellationToken ct) =>
            {
                (byte[]? bytes, string? contentType) = await svc.GetPartImageAsync(partNumber, ct);
                return bytes is null || contentType is null
                    ? Results.NotFound($"No image for part {partNumber}.")
                    : Results.File(bytes, contentType!, fileDownloadName: $"{partNumber}");
            });
            #endregion

            return app;
        }
    }
}
