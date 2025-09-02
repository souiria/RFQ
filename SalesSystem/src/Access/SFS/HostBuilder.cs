namespace SFS
{
    public static class HostBuilder
    {
        public static WebApplication CreateApp(WebApplicationBuilder? builder = null, params string[] args)
        {
            builder ??= WebApplication.CreateBuilder(args);

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
            string? connectionString = builder.Configuration.GetConnectionString("SfsDatabase");
            builder.Services.AddDbContext<SFSDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
            builder.Services.AddScoped(typeof(ISFSReadRepository<>), typeof(SFSRepository<>));
            builder.AddServiceDefaults();
            builder.Logging.AddSeq();
            builder.Services.AddGrpc();
            //builder.Services.AddInfrastructure(builder.Configuration);
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
            app.MapGrpcService<SFSGrpcService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            #endregion

            return app;
        }
    }
}