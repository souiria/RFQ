namespace NPR
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
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });
            builder.Services.AddInfrastructure(builder.Configuration);
            IAsyncPolicy<HttpResponseMessage> policy = GetRetryPolicy();
            builder.Services.AddHttpClient("MyClient").AddPolicyHandler(policy);
            builder.Services.AddSingleton<INPRAccessService, NPRAccessService>();
            builder.Services.AddHostedService<DataImportSchedulerService>();

            static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
            {
                int retryCount = 3;

                HttpStatusCode tooManyRequests = HttpStatusCode.TooManyRequests;

                bool IsTooManyRequests(HttpResponseMessage msg) => msg.StatusCode == tooManyRequests;

                void OnRetry(DelegateResult<HttpResponseMessage> outcome, TimeSpan timespan, int attempt, Context context)
                {
                    string reason = outcome.Exception?.Message ?? outcome.Result.StatusCode.ToString();
                    Console.WriteLine($"Retry {attempt} after {timespan.TotalSeconds}s due to: {reason}");
                }

                TimeSpan SleepDuration(int attempt)
                {
                    double value = Math.Pow(2, attempt);
                    TimeSpan returnTime = TimeSpan.FromMilliseconds(value);
                    return returnTime;
                }

                PolicyBuilder<HttpResponseMessage> transientErrorPolicy = HttpPolicyExtensions.HandleTransientHttpError();

                PolicyBuilder<HttpResponseMessage> extendedPolicy = transientErrorPolicy.OrResult(IsTooManyRequests);

                IAsyncPolicy<HttpResponseMessage> retryPolicy = extendedPolicy.WaitAndRetryAsync(retryCount, SleepDuration, OnRetry);

                return retryPolicy;
            }
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
            app.UseCors();
            app.MapGrpcService<NPRGrpcService>()
             .EnableGrpcWeb();
                app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            #endregion

            return app;
        }
    }
}
