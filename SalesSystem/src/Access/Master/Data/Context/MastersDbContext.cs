namespace Master.Data.Context
{
    public class MastersDbContext : DbContext, IMastersDbContext
    {
        readonly IDomainEventsDispatcher _Dispatcher;

        public MastersDbContext(DbContextOptions<MastersDbContext> options, IDomainEventsDispatcher dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }

        #region DbSet

        public DbSet<DbCurrency> CurrencyItems => Set<DbCurrency>();
        public DbSet<DbCustomerBusinessHierarchy> CustomerBusinessUnitItems => Set<DbCustomerBusinessHierarchy>();
        public DbSet<DbCustomerBusinessUserAssociation> CustomerBusinessUserAssociationItems => Set<DbCustomerBusinessUserAssociation>();
        public DbSet<DbCustomerHierarchy> CustomerLocationItems => Set<DbCustomerHierarchy>();
        public DbSet<DbCustomerProjectAssociation> CustomerProjectAssociationItems => Set<DbCustomerProjectAssociation>();
        public DbSet<DbCustomerSalesEntity> CustomerSalesEntityItems => Set<DbCustomerSalesEntity>();
        public DbSet<DbMilestoneHierarchy> MilestoneHierarchyItems => Set<DbMilestoneHierarchy>();
        public DbSet<DbPlatformHierarchy> PlatformItems => Set<DbPlatformHierarchy>();
        public DbSet<DbProgramHierarchy> ProgramItems => Set<DbProgramHierarchy>();
        public DbSet<DbProjectHierarchy> ProjectItems => Set<DbProjectHierarchy>();
        public DbSet<DbVehicle> VehicleItems => Set<DbVehicle>();
        public DbSet<DbSupplierGroup> SupplierGroup => Set<DbSupplierGroup>();
        public DbSet<DbSupplier> Supplier => Set<DbSupplier>();
        public DbSet<DbUnitOfMeasure> UnitOfMeasures => Set<DbUnitOfMeasure>();
        public DbSet<DbBusinessUnit> BusinessUnits => Set<DbBusinessUnit>();
        public DbSet<DbProjectEngineeringAssociation> ProjectEngineeringAssociations => Set<DbProjectEngineeringAssociation>();

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
