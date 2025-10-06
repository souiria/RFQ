namespace Rfq
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
            builder.Services.AddGrpc();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddSingleton<IRfqAccessService, RfqAccessService>();
            builder.Services.AddSingleton<IAdssService, AdssService>();
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
            app.MapGrpcService<RfqGrpcService>();
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
