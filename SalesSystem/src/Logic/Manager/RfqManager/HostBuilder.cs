namespace RfqModule
{
    public static class HostBuilder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {

            builder ??= WebApplication.CreateBuilder(args);

            #region Builder

            #region Kestrel
            // ===== KESTREL CONFIGURATION =====
            builder.WebHost.ConfigureKestrel(options =>
            {
                // Increase message size limits
                options.Limits.MaxRequestBodySize = 64 * 1024 * 1024; // 256 MB

                // Increase timeouts
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);

                // Disable minimum data rate (important for large/slow responses)
                options.Limits.MinResponseDataRate = null;
                options.Limits.MinRequestBodyDataRate = null;

                // HTTP/2 specific settings
                options.Limits.Http2.MaxStreamsPerConnection = 100;
                options.Limits.Http2.HeaderTableSize = 4096;
                options.Limits.Http2.MaxFrameSize = 16384;
                options.Limits.Http2.MaxRequestHeaderFieldSize = 8192;
                options.Limits.Http2.InitialConnectionWindowSize = 64 * 1024;
                options.Limits.Http2.InitialStreamWindowSize = 96 * 1024;
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

            builder.Logging.AddSeq();
            builder.Services.AddGrpc(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            });
            builder.Services.AddSingleton<IRfqManagerService, RfqManagerService>();
            builder.Services.AddGrpcClient<MasterClient>(o =>
            {
                o.Address = new Uri("https://localhost:7101");
            });
            builder.Services.AddGrpcClient<Rfq.Rfq.RfqClient>(o =>
            {
                o.Address = new Uri("https://localhost:7116");
            }).ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            new SocketsHttpHandler
            {
                PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                EnableMultipleHttp2Connections = true
            })
            .ConfigureHttpClient(client =>
            {
                client.Timeout = TimeSpan.FromSeconds(600); // 60 seconds timeout
            });

            // Configure resilience policy to allow longer timeouts
            builder.Services.Configure<HttpStandardResilienceOptions>("GrpcClient.Rfq.Rfq+RfqClient", options =>
            {
                options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(10);
                options.AttemptTimeout.Timeout = TimeSpan.FromMinutes(5);
            });

            builder.Services.AddGrpcClient<Emacs.Emacs.EmacsClient>(o =>
            {
                o.Address = new Uri("https://localhost:7285");
            })
            .ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            new SocketsHttpHandler
            {
                PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                EnableMultipleHttp2Connections = true
            })
            .ConfigureHttpClient(client =>
            {
                client.Timeout = TimeSpan.FromSeconds(600); // 60 seconds timeout
            });
            builder.Services.AddGrpcClient<Adss.AdssGrpc.AdssGrpcClient>(o =>
            {
                o.Address = new Uri("https://localhost:7117");
            });
            builder.Services.AddGrpcClient<NPR.NPR.NPRClient>(o =>
            {
                o.Address = new Uri("https://localhost:7265");
            });
            builder.Services.AddGrpcClient<CPD.CPD.CPDClient>(o =>
            {
                o.Address = new Uri("https://localhost:7166");
            });

            // whatever you set after this is bs
            builder.AddServiceDefaults();

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
