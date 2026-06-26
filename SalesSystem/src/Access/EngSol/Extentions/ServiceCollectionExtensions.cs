namespace EngSol.Extentions
{
    public static class ServiceCollectionExtensions
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
            //DbContextOptionsBuilder options = DbContextOptionsBuilder<EngSolDbContext>();
            TimeSpan retryDelay = TimeSpan.FromSeconds(30);

            services.AddScoped(typeof(IEngSolReadRepository<>), typeof(EngSolRepository<>));
            services.AddScoped(typeof(IEngSolRepository<>), typeof(EngSolRepository<>));
            services.AddDbContext<EngSolDbContext>(
                options => options
                    .UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.UseCompatibilityLevel(130);
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: retryDelay,
                        errorNumbersToAdd: null);
                    }));

            services.AddScoped<IEngSolDbContext>(sp => sp.GetRequiredService<EngSolDbContext>());

            return services;
        }

        static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssembliesOf(typeof(ServiceCollectionExtensions))
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

            services.Scan(scan => scan.FromAssembliesOf(typeof(ServiceCollectionExtensions))
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
