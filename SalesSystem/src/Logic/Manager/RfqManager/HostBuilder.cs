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
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = 64 * 1024 * 1024;
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);
                options.Limits.MinResponseDataRate = null;
                options.Limits.MinRequestBodyDataRate = null;

                // HTTP/2 settings
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

            #region Additional Services

            builder.Logging.AddSeq();

            builder.Services.AddGrpc(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024;
                options.MaxSendMessageSize = 64 * 1024 * 1024;
            });

            builder.Services.AddSingleton<IRfqManagerService, RfqManagerService>();

            // -----------------------------
            //  RFQ ACCESS CLIENT (FIXED)
            // -----------------------------
            builder.Services.AddGrpcClient<Rfq.Rfq.RfqClient>(o =>
            {
                o.Address = new Uri("https://localhost:7116");
            }).ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
  .ConfigurePrimaryHttpMessageHandler(() =>
  {
      return new SocketsHttpHandler
      {
          // No override needed because certificate is trusted
          PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
          KeepAlivePingDelay = TimeSpan.FromSeconds(60),
          KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
          EnableMultipleHttp2Connections = true
      };
  })
  .ConfigureChannel(options =>
  {
      options.MaxReceiveMessageSize = 64 * 1024 * 1024;
      options.MaxSendMessageSize = 64 * 1024 * 1024;
  })
  .ConfigureHttpClient(client =>
  {
      client.Timeout = TimeSpan.FromSeconds(600);
  });

            // Long timeouts for RFQ
            builder.Services.Configure<HttpStandardResilienceOptions>("GrpcClient.Rfq.Rfq+RfqClient", options =>
            {
                options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(10);
                options.AttemptTimeout.Timeout = TimeSpan.FromMinutes(5);
            });

            // -------------- Other clients unchanged --------------
            builder.Services.AddGrpcClient<MasterClient>(o =>
            {
                o.Address = new Uri("http://localhost:37001");
            });

            builder.Services.AddGrpcClient<Emacs.Emacs.EmacsClient>(o =>
            {
                o.Address = new Uri("https://localhost:7285");
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new SocketsHttpHandler
                {
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                    EnableMultipleHttp2Connections = true
                };
            });

            builder.Services.AddGrpcClient<Adss.AdssGrpc.AdssGrpcClient>(o =>
            {
                o.Address = new Uri("https://localhost:37004");
            });

            builder.Services.AddGrpcClient<NPR.NPR.NPRClient>(o =>
            {
                o.Address = new Uri("https://localhost:7265");
            });

            builder.Services.AddGrpcClient<CPD.CPD.CPDClient>(o =>
            {
                o.Address = new Uri("https://localhost:7166");
            });

            builder.AddServiceDefaults();
            builder.Services.AddInfrastructure();
            #endregion

            #endregion

            #region App

            WebApplication app = builder.Build();

            ILogger<WebApplication> logger = app.Services
                .GetRequiredService<ILogger<WebApplication>>();

            //logger.LogInformation(
            //    "RfqManager service started at {Timestamp}. Environment: {Environment}" + 
            //    DateTime.UtcNow +
            //    app.Environment.EnvironmentName);

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            app.MapGrpcService<RfqGrpcService>();
            app.MapGet("/", () =>
                "RFQ Manager running. gRPC calls available.");

            #endregion

            return app;
        }
    }
}