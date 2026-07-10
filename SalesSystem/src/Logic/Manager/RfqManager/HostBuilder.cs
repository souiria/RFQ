namespace RfqModule
{
    public static class HostBuilder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {

            //string dir = Directory.GetCurrentDirectory();
            builder ??= WebApplication.CreateBuilder(args);
            IConfigurationSection conf = builder.Configuration.GetSection("Logging");

            builder.Configuration
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            #region Builder
            //
            //IConfigurationSection grpc = builder.Configuration.GetSection("GrpcService");
            string? coreUrl = builder.Configuration["GrpcService:Core-Url"]
                   ?? throw new InvalidOperationException("GrpcService:Core-Url is missing in configuration.");
            string? adssUrl = builder.Configuration["GrpcService:Adss-Url"]
                   ?? throw new InvalidOperationException("GrpcService:Adss-Url is missing in configuration.");
            string? masterUrl = builder.Configuration["GrpcService:Master-Url"]
                   ?? throw new InvalidOperationException("GrpcService:Master-Url is missing in configuration.");
            string? rfqUrl = builder.Configuration["GrpcService:RFQ-Url"]
                   ?? throw new InvalidOperationException("GrpcService:RFQ-Url is missing in configuration.");
            string? cpdUrl = builder.Configuration["GrpcService:CPD-Url"]
                   ?? throw new InvalidOperationException("GrpcService:CPD-Url is missing in configuration.");
            string? emacUrl = builder.Configuration["GrpcService:Emac-Url"]
                   ?? throw new InvalidOperationException("GrpcService:Emac-Url is missing in configuration.");
            string? nprUrl = builder.Configuration["GrpcService:Npr-Url"]
                   ?? throw new InvalidOperationException("GrpcService:Npr-Url is missing in configuration.");
            string? purchasingUrl = builder.Configuration["GrpcService:Purchasings-Url"]
                   ?? throw new InvalidOperationException("GrpcService:Purchasings-Url is missing in configuration.");
            //string? dsiUrl = builder.Configuration["GrpcService:Dsi-Url"]
            //  ?? throw new InvalidOperationException("GrpcService:dsi-Url is missing in configuration.");
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

            static X509Certificate2 FindMatchingCertificateBySubject(string subjectCommonName)
            {
                using X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);

                DateTime now = DateTime.UtcNow;

                X509Certificate2? matchingCert = store.Certificates
                    .OfType<X509Certificate2>()
                    .Where(cert =>
                        cert.HasPrivateKey &&
                        //now >= cert.NotBefore &&
                        now <= cert.NotAfter &&
                        cert.Subject.Contains(subjectCommonName, StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(cert => cert.NotAfter)
                    .FirstOrDefault();

                if (matchingCert == null)
                {
                    throw new InvalidOperationException(
                        $"Certificate '{subjectCommonName}' not found in LocalMachine\\My");
                }

                return matchingCert;
            }

            // Helper to create SocketsHttpHandler with optional client certificate
            SocketsHttpHandler CreateHandlerWithClientCert()
            {
                SocketsHttpHandler handler = new SocketsHttpHandler
                {
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                    EnableMultipleHttp2Connections = true
                };

                try
                {
#if DEBUG
                    X509Certificate2 cert = FindMatchingCertificateBySubject("CN=localhost");
#else
                    X509Certificate2 cert = FindMatchingCertificateBySubject("*.sews-e.com");
#endif
                    handler.SslOptions.ClientCertificates ??= new X509CertificateCollection();
                    handler.SslOptions.ClientCertificates.Add(cert);
                 
#pragma warning disable CA5359 // Do Not Disable Certificate Validation
                    handler.SslOptions.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                    {
                        //Accept any server certificate(not recommended for production)
                        
                            return true;
                    };
#pragma warning restore CA5359 // Do Not Disable Certificate Validation

                    //}
                }
                catch (Exception ex) 
                {
                        // Log the exception if logging is available, otherwise ignore
                        Console.WriteLine($"Error loading client certificate: {ex.Message}");
                    // Suppress certificate loading errors during service registration
                    throw;
                }

                return handler;
            }

            // -----------------------------
            //  RFQ ACCESS CLIENT 
            // -----------------------------
            builder.Services.AddGrpcClient<Rfq.Rfq.RfqClient>(o =>
            {
                o.Address = new Uri(rfqUrl);
            }).ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
            .ConfigurePrimaryHttpMessageHandler(CreateHandlerWithClientCert)
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
                o.Address = new Uri(masterUrl);
            }).ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
            .ConfigurePrimaryHttpMessageHandler(CreateHandlerWithClientCert);

            builder.Services.AddGrpcClient<Emacs.Emacs.EmacsClient>(o =>
            {
                o.Address = new Uri(emacUrl);
            })
            .ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
            .ConfigurePrimaryHttpMessageHandler(CreateHandlerWithClientCert);

            builder.Services.AddGrpcClient<Adss.AdssGrpc.AdssGrpcClient>(o =>
            {
                o.Address = new Uri(adssUrl);
            }).ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
            .ConfigurePrimaryHttpMessageHandler(CreateHandlerWithClientCert);

            builder.Services.AddGrpcClient<NPR.NPR.NPRClient>(o =>
            {
                o.Address = new Uri(nprUrl);
            }).ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
            .ConfigurePrimaryHttpMessageHandler(CreateHandlerWithClientCert);

            builder.Services.AddGrpcClient<CPD.CPD.CPDClient>(o =>
            {
                o.Address = new Uri(cpdUrl);
            }).ConfigureChannel(options =>
            {
                options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
                options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
            })
            .ConfigurePrimaryHttpMessageHandler(CreateHandlerWithClientCert);
      //      builder.Services.AddGrpcClient<DSI.DSI.DSIClient>(o =>
      //      {
      //          o.Address = new Uri(dsiUrl);
      //      }).ConfigureChannel(options =>
      //      {
      //          options.MaxReceiveMessageSize = 64 * 1024 * 1024; // 16 MB
      //          options.MaxSendMessageSize = 64 * 1024 * 1024;    // 16 MB
      //      })
      //.ConfigurePrimaryHttpMessageHandler(CreateHandlerWithClientCert);

            builder.AddServiceDefaults();
            builder.Services.AddInfrastructure();
            builder.Services.AddHttpContextAccessor();
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