namespace Unit4.Data.Context
{
    /// <summary>
    /// The database context for H1.Sales.Edi entities.
    /// </summary>
    class Unit4DbContext : DbContext, IUnit4DbContext
    {
        readonly IDomainEventsDispatcher _Dispatcher;

        /// <summary>
        /// Creates a <see cref="Unit4DbContext"/>.
        /// </summary>
        public Unit4DbContext(DbContextOptions<Unit4DbContext> options, IDomainEventsDispatcher dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }

        #region DbSet

        public DbSet<DbAlgBatchInput> AlgBatchInputs => Set<DbAlgBatchInput>();
        public DbSet<DbAlgProductInput> AlgProductInputs => Set<DbAlgProductInput>();
        public DbSet<DbMinAlgArticle> MinAlgArticles => Set<DbMinAlgArticle>();
        public DbSet<DbUnit4SalesOrdersView> Unit4SalesOrdersViewItems => Set<DbUnit4SalesOrdersView>();

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Assembly assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        #endregion

        #region SaveChanges

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
