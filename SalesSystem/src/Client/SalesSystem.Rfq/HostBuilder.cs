namespace SalesSystem.Rfq
{
    public static class HostBuilder
    {
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {

            builder ??= WebApplication.CreateBuilder(args);

            #region Builder
            builder.Configuration
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            string? managerUrl = builder.Configuration["GrpcService:Url"]
            ?? throw new InvalidOperationException("GrpcService:Url is missing in configuration.");

            int timeoutSeconds = int.TryParse(builder.Configuration["GrpcService:TimeoutSeconds"], out int t)
                ? t
                : 120;

            // Add service defaults & Aspire client integrations.
            builder.AddServiceDefaults();
            builder.Logging.AddSeq();

            //Add Authentication for User
            builder.AddUserAuthentication();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddOutputCache();

            builder.Services.AddMudServices();

            // *********************************************************************
            // Add additional generic services here (anything ServiceFabric specific
            // should go in Api.cs CreateServiceInstanceListeners method)
            // *********************************************************************

            #region Additional Services

            //StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
            builder.Services.AddRfqUxServices();
            builder.Services.AddGrpcClient<RfqModule.RfqModule.RfqModuleClient>(o =>
            {
                o.Address = new Uri(managerUrl);

            })
            .ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 256 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 256 MB
            });

            #endregion

            #endregion

            #region App

            WebApplication app = builder.Build();
            // Add this test log
            ILogger<Program> logger = app.Services.GetRequiredService<ILogger<Program>>();
            logger.GenericLogInformation("III RFQ UX Client starting up - SEQ test message");

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); 
            app.UseRouting();
            app.UseAuthorization();
            app.UseAntiforgery();
           // app.MapBlazorHub();     // REQUIRED
            //app.MapStaticAssets();
            app.MapRazorPages().WithStaticAssets();
            app.MapRazorComponents<App>()
                .WithStaticAssets()
                .AddInteractiveServerRenderMode();

            #endregion

            return app;
        }
    }
}