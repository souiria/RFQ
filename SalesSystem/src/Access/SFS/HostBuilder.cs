using System;
using System.Collections.Generic;
using Google.Protobuf.Compiler;
using Grpc.AspNetCore.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace SFS
{
    public static class HostBuilder
    {
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {
            builder ??= WebApplication.CreateBuilder(args);
  
            string serviceName = Environment.GetEnvironmentVariable("OTEL_SERVICE_NAME") ?? "SFS";
            string environmentName = builder.Environment.EnvironmentName ?? "Development";

            TextMapPropagator[] propagators = new TextMapPropagator[]
            {
                new TraceContextPropagator(),
                new BaggagePropagator()
            };
            CompositeTextMapPropagator compositePropagator = new CompositeTextMapPropagator(propagators);
            Sdk.SetDefaultTextMapPropagator(compositePropagator);
            IOpenTelemetryBuilder otel = builder.Services.AddOpenTelemetry();

            otel.ConfigureResource(resourceBuilder =>
            {
                string version = GetVersion();
                resourceBuilder.AddService(serviceName: serviceName, serviceVersion: version);
                KeyValuePair<string, object>[] attrs = new KeyValuePair<string, object>[]
                {
                    new KeyValuePair<string, object>("deployment.environment", environmentName)
                };

                resourceBuilder.AddAttributes(attrs);
            });
            otel.WithTracing(traces =>
            {
                traces.AddAspNetCoreInstrumentation(o => { o.RecordException = true; })
                      .AddHttpClientInstrumentation(o => { o.RecordException = true; })
                      .AddOtlpExporter(o =>
                      {
                          string otlpBase = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT")
                           ?? "http://localhost:8200";
                                                
                            string? otlpHeaders = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_HEADERS");
                          
                          o.Protocol = OtlpExportProtocol.HttpProtobuf;
                          o.Endpoint = new Uri(otlpBase);
                          o.Headers = otlpHeaders;
                      });
            });
            otel.WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                       .AddHttpClientInstrumentation()
                       .AddRuntimeInstrumentation()
                      
                       .AddOtlpExporter(o =>
                       {
                           string otlpBase = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT")
                        ?? "http://localhost:8200";

                          string? otlpHeaders = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_HEADERS");
                           o.Protocol = OtlpExportProtocol.HttpProtobuf;
                           o.Endpoint = new Uri(otlpBase);
                           o.Headers = otlpHeaders;
                       });
            });
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddSeq();
 
            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            builder.Services.AddEndpointsApiExplorer();

            string? connectionString = builder.Configuration.GetConnectionString("SfsDatabase");
            builder.Services.AddDbContext<SFSDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
            builder.Services.AddScoped(typeof(ISFSReadRepository<>), typeof(SFSRepository<>));
            builder.AddServiceDefaults();
            builder.Services.AddGrpc();

            builder.Services.AddScoped<ISFSAccessService, SFSAccessService>();
            builder.Services.AddScoped(typeof(IQueryHandler<GetCalculationTypeQuery, List<CalculationTypeViewGrpc>>), typeof(CQRS.Handler.CalculationType.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetAllCarModelQuery, List<CarModelViewGrpc>>), typeof(CQRS.Handler.CarModel.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetAllCustomerQuery, List<CustomerViewGrpc>>), typeof(CQRS.Handler.Customer.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetCustomerNonWorkingDaysQuery, List<CustomerNonWorkingDayViewGrpc>>), typeof(CQRS.Handler.CustomerNonWorkingDays.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetDailyVolumeDataQuery, List<DailyVolumeDataViewGrpc>>), typeof(CQRS.Handler.DailyVolumeData.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetForecastQuery, List<ForecastViewGrpc>>), typeof(CQRS.Handler.Forecast.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetMonthlyVolumeDataQuery, List<MonthlyVolumeDataViewGrpc>>), typeof(CQRS.Handler.MonthlyVolumeData.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetPeriodQuery, List<PeriodViewGrpc>>), typeof(CQRS.Handler.Period.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetProfileQuery, List<ProfileViewGrpc>>), typeof(CQRS.Handler.Profile.QueryHandler));
            builder.Services.AddScoped(typeof(IQueryHandler<GetSiteQuery, List<SiteViewGrpc>>), typeof(CQRS.Handler.Site.QueryHandler));
 
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

            app.MapGrpcService<SFSGrpcService>();
            app.MapGet("/", () =>
                "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            return app;
        }

        static string GetVersion()
        {
            return typeof(HostBuilder).Assembly.GetName().Version?.ToString() ?? "1.0.0";
        }
    }
}
