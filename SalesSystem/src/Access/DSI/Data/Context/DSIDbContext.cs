namespace DSI.Data.Context
{
    public class DSIDbContext : DbContext, IDSIDbContext
    {
        readonly IDomainEventsDispatcher? _Dispatcher;

        public DSIDbContext(DbContextOptions<DSIDbContext> options, IDomainEventsDispatcher? dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }

        #region DbSet

        public DbSet<DbBranchInsulation> DSIBranchInsulation => Set<DbBranchInsulation>();
         public DbSet<DbComponent> DSIComponent => Set<DbComponent>();

        public DbSet<DbCompositeDetail> DSICompositeDetail => Set<DbCompositeDetail>();
 
        public DbSet<DbHarness> DSIHarness => Set<DbHarness>();

        public DbSet<DbWireSpecification> DsiWireSpecification => Set<DbWireSpecification>();

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
            if (_Dispatcher is null)
            {
                return;
            }

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
