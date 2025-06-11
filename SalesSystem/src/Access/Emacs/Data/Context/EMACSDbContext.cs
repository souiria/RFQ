namespace Emacs.Data.Context
{
    public class EMACSDbContext : DbContext, IEMACSDbContext
    {
        readonly IDomainEventsDispatcher _Dispatcher;

        public EMACSDbContext(DbContextOptions<EMACSDbContext> options, IDomainEventsDispatcher dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }
        #region DbSet
        public DbSet<DbCombinedParts> CombinedParts => Set<DbCombinedParts>();
        public DbSet<DbPartCategoryDetail> PartCategoryDetails => Set<DbPartCategoryDetail>();
        public DbSet<DbPartClassDetail> PartClassDetail => Set<DbPartClassDetail>();

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Assembly assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        #endregion

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
