namespace EDI.Data.Context
{
    /// <summary>
    /// The database context for H1.Sales.Edi entities.
    /// </summary>
    class EdiDbContext : DbContext, IEdiDbContext
    {
        readonly IDomainEventsDispatcher _Dispatcher;

        /// <summary>
        /// Creates a <see cref="EdiDbContext"/>.
        /// </summary>
        public EdiDbContext(DbContextOptions<EdiDbContext> options, IDomainEventsDispatcher dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }

        #region DbSet

        public DbSet<DbEdiFileDataUpload> EdiFileDataUploads => Set<DbEdiFileDataUpload>();
        public DbSet<DbEdiFileDataUploadDuplicate> EdiFileDataUploadDuplicates => Set<DbEdiFileDataUploadDuplicate>();
        public DbSet<DbEdiInvoiceInformation> EdiInvoiceInformation => Set<DbEdiInvoiceInformation>();
        public DbSet<DbEdiCustomerParameter> EdiCustomerParameters => Set<DbEdiCustomerParameter>();
        public DbSet<DbEdiGlobalParameter> EdiGlobalParameters => Set<DbEdiGlobalParameter>();
        public DbSet<DbZeroPriceExceptions> ZeroPriceExceptions => Set<DbZeroPriceExceptions>();

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
