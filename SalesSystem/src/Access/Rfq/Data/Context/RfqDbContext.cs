namespace Rfq.Data.Context
{
    public class RfqDbContext : DbContext, IRfqDbContext
    {
        readonly IDomainEventsDispatcher _Dispatcher;

        public RfqDbContext(DbContextOptions<RfqDbContext> options, IDomainEventsDispatcher dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }

        #region DbSet
        public DbSet<DbRfqDrawingPartNumber> RfqDrawingPartNumber => Set<DbRfqDrawingPartNumber>();
        public DbSet<DbRfqProject> RfqProject => Set<DbRfqProject>();
        public DbSet<DbRfqNotes> RfqNotes => Set<DbRfqNotes>();
        public DbSet<DbRfqReason> RfqReason => Set<DbRfqReason>();
        public DbSet<DbDsiBend> DsiBend => Set<DbDsiBend>();
        public DbSet<DbDsiBranchConfiguration> DsiBranchConfiguration => Set<DbDsiBranchConfiguration>();
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
