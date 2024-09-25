namespace CommercialService2.Api;

public static class CommercialService2HostBuilder
{
    public static WebApplication CreateApp(WebApplicationBuilder builder = null, StatelessServiceContext serviceContext = null,  params string[] args)
    {
        builder ??= WebApplication.CreateBuilder(args);

        #region Builder

        var logConfig = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
            .Enrich.WithProperty("Application", "CommercialService2")
            .WriteTo.Console(Formatters.CreateConsoleTextFormatter(theme: TemplateTheme.Code))
            .WriteTo.Seq(Environment.GetEnvironmentVariable("SEQ_URL") ?? "http://localhost:5341");
            if (serviceContext != null)
            {
                logConfig.Enrich.WithProperty("ServiceTypeName", serviceContext.ServiceTypeName)
                    .Enrich.WithProperty("ServiceName", serviceContext.ServiceName)
                    .Enrich.WithProperty("PartitionId", serviceContext.PartitionId)
                    .Enrich.WithProperty("InstanceId", serviceContext.ReplicaOrInstanceId)
                    .Enrich.WithProperty("NodeName", serviceContext.NodeContext.NodeName);
            }

        using var log = logConfig.CreateLogger();

        using var listener = new ActivityListenerConfiguration()
            .Instrument.AspNetCoreRequests()
            .TraceToSharedLogger();

        builder.Services.AddSingleton<Serilog.ILogger>(log);
        log.Information(serviceContext != null
            ? $"Api Service has started on SecureServiceEndpoint {args[0]}"
            : "Serilog configured for local debug!");


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
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CommercialService2 API", Version = "v1" });
            //c.EnableAnnotations();
        });

        builder.Services.AddMassTransit(x =>
        {
            var clusterName = builder.Configuration.GetValue<string>("RabbitClusterName") ?? "";
            var nodeNames = builder.Configuration.GetValue<string>("RabbitServerList") ?? "";
            x.UsingRabbitMq((context, config) =>
            {
                config.Host(new Uri(clusterName), "/", h =>
                {
                    h.Username("user");
                    h.Password("password");
                    h.UseCluster(c =>
                    {
                        string[] hostnames = nodeNames.Split(";");
                        foreach (string hostname in hostnames)
                        {
                            c.Node(hostname);
                        }
                    });
                });
                config.SetQuorumQueue();
                config.ConfigureEndpoints(context);
            });
        });

        // Add additional generic services here (anything ServiceFabric specific
        // should go in Api.cs CreateServiceInstanceListeners method)

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
        
        #endregion

        return app;
    }
}
