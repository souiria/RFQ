using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using SalesSystem.ServiceDefaults;
using SharedKernel;
using Microsoft.AspNetCore.Authentication.Negotiate;
using OpenTelemetry.Resources;
using Elastic.OpenTelemetry;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Hosting
{
    // Adds common .NET Aspire services: service discovery, resilience, health checks, and OpenTelemetry.
    // This project should be referenced by each service project in your solution.
    // To learn more about using this project, see https://aka.ms/dotnet/aspire/service-defaults
    public static class Extensions
    {

        public static TBuilder AddUserAuthentication<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;
            });
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<CustomAuthenticationStateProvider>());
            builder.Services.AddHttpContextAccessor();

            return builder;
        }
 
        public static TBuilder AddServiceDefaults<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {

            builder.ConfigureOpenTelemetry();

            builder.AddDefaultHealthChecks();

            builder.Services.AddServiceDiscovery();

            builder.Services.ConfigureHttpClientDefaults(http =>
            {
                // Turn on resilience by default
                http.AddStandardResilienceHandler();

                // Turn on service discovery by default
                http.AddServiceDiscovery();
            });

            // Uncomment the following to restrict the allowed schemes for service discovery.
            // builder.Services.Configure<ServiceDiscoveryOptions>(options =>
            // {
            //     options.AllowedSchemes = ["https"];
            // });

            return builder;
        }

        public static TBuilder ConfigureOpenTelemetry<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.Logging.AddOpenTelemetry(logging =>
            {
                logging.IncludeFormattedMessage = true;
                logging.IncludeScopes = true;
            });

            builder.Services.AddOpenTelemetry()
                .WithMetrics(metrics =>
                {
                    metrics.AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddRuntimeInstrumentation();
                })
                .WithTracing(tracing =>
                {
                    tracing.AddSource(builder.Environment.ApplicationName)
                        .AddAspNetCoreInstrumentation()
                        // Uncomment the following line to enable gRPC instrumentation (requires the OpenTelemetry.Instrumentation.GrpcNetClient package)
                        .AddGrpcClientInstrumentation()
                        .AddHttpClientInstrumentation();                                   
                });

            builder.AddOpenTelemetryExporters();

            return builder;
        }

        static TBuilder AddOpenTelemetryExporters<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            bool useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);
            bool useAPM = !string.IsNullOrWhiteSpace(builder.Configuration["ELASTIC_OTEL_EXPORTER_OTLP_ENDPOINT"]);

            //Use Aspire if no APM endpoint set
            if (useOtlpExporter & !useAPM)
            {
                builder.Services.AddOpenTelemetry().UseOtlpExporter();
            }

            //Use APM if endpoint is set
            if (useOtlpExporter & useAPM) 
            {       
                string test = builder.Configuration["ELASTIC_OTEL_EXPORTER_OTLP_ENDPOINT"]!;
                //http://localhost:8200/v1/logs

                builder.Services.AddElasticOpenTelemetry().ConfigureResource(
                     resourceBuilder => resourceBuilder.AddService(builder.Environment.ApplicationName)
                 )
                 .WithMetrics(metrics =>
                                    {
                                        metrics.AddAspNetCoreInstrumentation()
                                            .AddHttpClientInstrumentation()
                                            .AddRuntimeInstrumentation()
                                           // .AddMeter("Microsoft.AspNetCore.Hosting")
                                           // .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
                                          //  .AddMeter("Microsoft.AspNetCore.Http.Connections")
                                            //.AddMeter("Microsoft.AspNetCore.Routing")
                                           // .AddMeter("Microsoft.AspNetCore.Diagnostics")
                                           //  .AddMeter("Microsoft.AspNetCore.RateLimiting")
                                            .AddOtlpExporter("metrics", opt =>
                                               {
                                                   opt.Protocol = OpenTelemetry
                                                   .Exporter
                                                   .OtlpExportProtocol
                                                   .HttpProtobuf;
                                                   opt.Endpoint = new Uri(
                                                   "http://localhost:8200/v1/metrics"
                                                    );
                                               });
                                    })
                 .WithTracing(
                     tracerProviderBuilder =>
                         tracerProviderBuilder
                             .AddSource(builder.Environment.ApplicationName)
                             .AddAspNetCoreInstrumentation()
                             .AddGrpcClientInstrumentation()
                             .AddHttpClientInstrumentation()
                             .AddSqlClientInstrumentation()
                             .AddOtlpExporter("trace", opt =>
                             {
                                 opt.Protocol = OpenTelemetry
                                     .Exporter
                                     .OtlpExportProtocol
                                     .HttpProtobuf;
                                 opt.Endpoint = new Uri(
                                     "http://localhost:8200/v1/traces"
                                 );
                             })
                 );

                //  builder.AddElasticOpenTelemetry(b => b.ConfigureResource(r => r.AddService(builder.Environment.ApplicationName))); 
            }

            // Uncomment the following lines to enable the Azure Monitor exporter (requires the Azure.Monitor.OpenTelemetry.AspNetCore package)
            if (!string.IsNullOrEmpty(builder.Configuration["AzureMonitor:ConnectionString"]))
            {                    
               // builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) =>  builder.AddProcessor(new ActivityEnrichingProcessor()));
                builder.Services.AddOpenTelemetry()
                   .UseAzureMonitor();
            }

  

            return builder;
        }

        public static TBuilder AddDefaultHealthChecks<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.Services.AddHealthChecks()
                // Add a default liveness check to ensure app is responsive
                .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

            return builder;
        }

        public static WebApplication MapDefaultEndpoints(this WebApplication app)
        {
            // Adding health checks endpoints to applications in non-development environments has security implications.
            // See https://aka.ms/dotnet/aspire/healthchecks for details before enabling these endpoints in non-development environments.
            if (app.Environment.IsDevelopment())
            {
                // All health checks must pass for app to be considered ready to accept traffic after starting
                app.MapHealthChecks("/health");

                // Only health checks tagged with the "live" tag must pass for app to be considered alive
                app.MapHealthChecks("/alive", new HealthCheckOptions
                {
                    Predicate = r => r.Tags.Contains("live")
                });
            }

            return app;
        }
    }
}
