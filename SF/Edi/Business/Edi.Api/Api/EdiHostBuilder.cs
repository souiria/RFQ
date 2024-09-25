namespace Edi.Api;

public static class EdiHostBuilder
{
    public static WebApplication CreateApp(WebApplicationBuilder builder = null, StatelessServiceContext serviceContext = null,  params string[] args)
    {
        builder ??= WebApplication.CreateBuilder(args);

        #region Builder

        builder.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        //builder.Services.AddControllersWithViews().AddNewtonsoftJson();
        //builder.Services.AddRazorPages();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Edi API", Version = "v1" });
            //c.EnableAnnotations();
        });
        
        // Add additional generic services here (anything ServiceFabric specific
        // should go in Api.cs CreateServiceInstanceListeners method)

        builder.Services.AddGrpc();

        #endregion

        #region App

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
        app.MapGrpcService<InvoiceInformationEndpoint>();
        
        #endregion

        return app;
    }
}
