namespace Edi.Api.Common.AutofacModules;
internal class DataAccessModule : Autofac.Module
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
    }
}
