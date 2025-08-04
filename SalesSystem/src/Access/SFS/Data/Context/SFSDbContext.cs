namespace SFS.Data.Context
{
    public class SFSDbContext : DbContext, ISFSDbContext
    {
        readonly IDomainEventsDispatcher _Dispatcher;
        public SFSDbContext(DbContextOptions<SFSDbContext> options, IDomainEventsDispatcher dispatcher)
            : base(options)
        {
            _Dispatcher = dispatcher;
        }
        #region DbSet
        public DbSet<DbCalculationType> CalculationItems => Set<DbCalculationType>();

        public DbSet<DbCarModel> CarItems => Set<DbCarModel>();

        public DbSet<DbCustomer> CustomerItems => Set<DbCustomer>();

        public DbSet<DbCustomerNonWorkingDays> CustomerNonWorkingDaysItems => Set<DbCustomerNonWorkingDays>();

        public DbSet<DbDailyVolumeData> DailyVolumeDataItems => Set<DbDailyVolumeData>();

        public DbSet<DbForecast> ForecastItems => Set<DbForecast>();

        public DbSet<DbMonthlyVolumeData> MonthlyVolumeDataItems => Set<DbMonthlyVolumeData>();

        public DbSet<DbPeriod> PeriodItems => Set<DbPeriod>();

        public DbSet<DbProfile> ProfileItems => Set<DbProfile>();

        public DbSet<DbSite> SiteItems => Set<DbSite>();

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SFSDbContext).Assembly);
        }
        #region Save Changes
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            await PublishDomainEventsAsync();
            return result;
        }
        public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();

        async Task PublishDomainEventsAsync()
        {
            List<IDomainEvent> domainEvents = ChangeTracker
                .Entries<Entity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    List<IDomainEvent> domainEvents = (List<IDomainEvent>)entity.DomainEvents;

                    entity.ClearDomainEvents();

                    return domainEvents;
                })
                .ToList();

            await _Dispatcher.DispatchAsync(domainEvents);
        }
        #endregion
    }
}
