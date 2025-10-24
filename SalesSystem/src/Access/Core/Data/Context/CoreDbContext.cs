namespace Core.Data.Context
{
    public class CoreDbContext : DbContext, ICoreDbContext
    {
        readonly IDomainEventsDispatcher _Dispatcher;
        public CoreDbContext(DbContextOptions<CoreDbContext> options, IDomainEventsDispatcher dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }
        #region DbSet

        public DbSet<DbUserList> UserListItems => Set<DbUserList>();
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
            foreach (IDomainEvent domainEvent in domainEvents)
            {
                await _Dispatcher.DispatchAsync(domainEvents);
            }
        }
        #endregion
    }
}
