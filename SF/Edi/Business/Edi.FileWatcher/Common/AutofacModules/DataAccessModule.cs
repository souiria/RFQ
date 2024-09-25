namespace Edi.FileWatcher.Common.AutofacModules;
internal class DataAccessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region EDI Database

        builder.Register(c =>
        {
            var connection = Environment.GetEnvironmentVariable("EDI_DATABASE_CONNECTION") ?? throw new InvalidOperationException("EDI_DATABASE_CONNECTION is null.");
            var opt = new DbContextOptionsBuilder<H1SalesEdiDbContext>();
            opt.UseSqlServer(connection, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.UseCompatibilityLevel(130);
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            });


            return new H1SalesEdiDbContext(opt.Options);
        }).AsSelf().InstancePerDependency();

        builder.RegisterGeneric(typeof(H1SalesEdiRepository<>))
            .As(typeof(ISalesEdiRepository<>)).InstancePerDependency()
            .As(typeof(ISalesEdiReadRepository<>)).InstancePerDependency();

        #endregion

        #region Unit4 Database

        builder.Register(c =>
        {
            var connection = Environment.GetEnvironmentVariable("UNIT4_DATABASE_CONNECTION") ?? throw new InvalidOperationException("UNIT4_DATABASE_CONNECTION is null.");
            var opt = new DbContextOptionsBuilder<Unit4DbContext>();
            opt.UseSqlServer(connection, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.UseCompatibilityLevel(130);
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            });

            return new Unit4DbContext(opt.Options);
        }).AsSelf().InstancePerDependency();

        builder.RegisterGeneric(typeof(Unit4Repository<>))
            .As(typeof(IUnit4Repository<>)).InstancePerDependency()
            .As(typeof(IUnit4ReadRepository<>)).InstancePerDependency();

        #endregion

        #region Quotation Database

        builder.Register(c =>
        {
            var connection = Environment.GetEnvironmentVariable("QUOTATION_DATABASE_CONNECTION") ?? throw new InvalidOperationException("QUOTATION_DATABASE_CONNECTION is null.");
            var opt = new DbContextOptionsBuilder<H1SalesQuotationDbContext>();
            opt.UseSqlServer(connection, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.UseCompatibilityLevel(130);
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            });

            return new H1SalesQuotationDbContext(opt.Options);
        }).AsSelf().InstancePerDependency();

        builder.RegisterGeneric(typeof(H1SalesQuotationRepository<>))
            .As(typeof(IQuotationSystemRepository<>)).InstancePerDependency()
            .As(typeof(IQuotationSystemReadRepository<>)).InstancePerDependency();

        #endregion
    }
}
