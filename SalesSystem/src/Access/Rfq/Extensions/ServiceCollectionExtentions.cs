namespace Rfq.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration) =>
       services
           .AddServices()
           .AddDatabase(configuration)
           .AddMediator();

        static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient<IDomainEventsDispatcher, DomainEventsDispatcher>();

            return services;
        }

        static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");
            //DbContextOptionsBuilder options = DbContextOptionsBuilder<MastersDbContext>();
            TimeSpan retryDelay = TimeSpan.FromSeconds(30);

            services.AddScoped(typeof(IRfqReadRepository<>), typeof(RfqRepository<>));
            services.AddScoped(typeof(IRfqRepository<>), typeof(RfqRepository<>));
            services.AddDbContext<RfqDbContext>(
                options => options
                    .UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.UseCompatibilityLevel(130);
                        sqlOptions.CommandTimeout(120);
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: retryDelay,
                        errorNumbersToAdd: null);
                    }));

            services.AddScoped<IRfqDbContext>(sp => sp.GetRequiredService<RfqDbContext>());

            return services;
        }

        static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssembliesOf(typeof(ServiceCollectionExtentions))
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            //services.Decorate(typeof(ICommandHandler<,>), typeof(ValidationDecorator.CommandHandler<,>));
            //services.Decorate(typeof(ICommandHandler<>), typeof(ValidationDecorator.CommandBaseHandler<>));

            //services.Decorate(typeof(IQueryHandler<,>), typeof(LoggingDecorator.QueryHandler<,>));
            //services.Decorate(typeof(ICommandHandler<,>), typeof(LoggingDecorator.CommandHandler<,>));
            //services.Decorate(typeof(ICommandHandler<>), typeof(LoggingDecorator.CommandBaseHandler<>));

            services.Scan(scan => scan.FromAssembliesOf(typeof(ServiceCollectionExtentions))
                .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventsHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            //services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly, includeInternalTypes: true);

            return services;
        }

        /// <summary>
        /// Not Currently in use
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHealthChecks(configuration);

            return services;
        }
    }
}
