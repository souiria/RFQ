namespace SalesSystem.Rfq
{
    public static class HostBuilder
    {
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {

            builder ??= WebApplication.CreateBuilder(args);

            #region Builder

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

            builder.Services.AddHttpClient<WeatherApiClient>(client =>
            {
                // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
                // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
                client.BaseAddress = new("https+http://api-service");
            });

            //builder.Services.AddGrpcClient<RfqData.InvoiceInformationServiceClient>(
            //    options =>
            //    {
            //        options.Address = new Uri("https://ukhqh1uat.sews-e.com:443");
            //    }
            //);

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
                o.Address = new Uri("https://localhost:7207");
            });

            #endregion

            #endregion

            #region App

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAntiforgery();
            //app.UseOutputCache();
            app.UseMiddleware<UserContextEnrichmentMiddleware>();
            app.MapStaticAssets();
            app.MapRazorPages().WithStaticAssets();
            app.MapRazorComponents<App>()
                .WithStaticAssets()
                .AddInteractiveServerRenderMode();

            //app.MapDefaultEndpoints();

            #endregion

            return app;
        }
    }
}