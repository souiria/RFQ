namespace Rfq.Data.Context
{
    public class RfqDbContext : DbContext, IRfqDbContext
    {
        readonly IDomainEventsDispatcher? _Dispatcher;

        public RfqDbContext(DbContextOptions<RfqDbContext> options, IDomainEventsDispatcher? dispatcher) : base(options)
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
        public DbSet<DbDsiBranchConfigurationBendAssociation> DsiBranchConfigurationBendAssociation => Set<DbDsiBranchConfigurationBendAssociation>();
        public DbSet<DbDsiBranchInsulation> DsiBranchInsulation => Set<DbDsiBranchInsulation>();
        public DbSet<DbDsiBranchInsulationThroughNode> DsiBranchInsulationThroughNode => Set<DbDsiBranchInsulationThroughNode>();
        public DbSet<DbDsiCavityMapping> DsiCavityMapping => Set<DbDsiCavityMapping>();
        public DbSet<DbDsiCentreStrip> DsiCentreStrip => Set<DbDsiCentreStrip>();
        public DbSet<DbDsiComponent> DsiComponent => Set<DbDsiComponent>();
        public DbSet<DbDsiCompositeDetail> DsiCompositeDetail => Set<DbDsiCompositeDetail>();
        public DbSet<DbDsiCompositeDetailCircuitOptionAssociation> DsiCompositeDetailCircuitOptionAssociation => Set<DbDsiCompositeDetailCircuitOptionAssociation>();
        public DbSet<DbDsiCompositeOption> DsiCompositeOption => Set<DbDsiCompositeOption>();
        public DbSet<DbDsiHarness> DsiHarness => Set<DbDsiHarness>();
        public DbSet<DbDsiHarnessScope> DsiHarnessScope => Set<DbDsiHarnessScope>();
        public DbSet<DbDsiHarnessScopeScopeAssociation> DsiHarnessScopeScopeAssociation => Set<DbDsiHarnessScopeScopeAssociation>();
        public DbSet<DbDsiManualBomQuantity> DsiManualBomQuantity => Set<DbDsiManualBomQuantity>();
        public DbSet<DbDsiMidWireComponent> DsiMidWireComponent => Set<DbDsiMidWireComponent>();
        public DbSet<DbDsiModuleChildDetail> DsiModuleChildDetail => Set<DbDsiModuleChildDetail>();
        public DbSet<DbDsiModuleCompatibility> DsiModuleCompatibility => Set<DbDsiModuleCompatibility>();
        public DbSet<DbDsiMulticoreSpecification> DsiMulticoreSpecification => Set<DbDsiMulticoreSpecification>();
        public DbSet<DbDsiPinMapping> DsiPinMapping => Set<DbDsiPinMapping>();
        public DbSet<DbDsiPinMappingCavityMappingAssociation> DsiPinMappingCavityMappingAssociation => Set<DbDsiPinMappingCavityMappingAssociation>();
        public DbSet<DbDsiScope> DsiScope => Set<DbDsiScope>();
        public DbSet<DbDsiSupplier> DsiSupplier => Set<DbDsiSupplier>();
        public DbSet<DbDsiTransformedCompositeDetail> DsiTransformedCompositeDetail => Set<DbDsiTransformedCompositeDetail>();
        public DbSet<DbDsiTransformedHarness> DsiTransformedHarness => Set<DbDsiTransformedHarness>();
        public DbSet<DbDsiTransformedModuleChildDetail> DsiTransformedModuleChildDetail => Set<DbDsiTransformedModuleChildDetail>();
        public DbSet<DbDsiUnitOfMeasure> DsiUnitOfMeasure => Set<DbDsiUnitOfMeasure>();
        public DbSet<DbDsiWireMulticoreMarker> DsiWireMulticoreMarker => Set<DbDsiWireMulticoreMarker>();
        public DbSet<DbDsiWireSpecification> DsiWireSpecification => Set<DbDsiWireSpecification>();
        public DbSet<DbDsiWireThroughNode> DsiWireThroughNode => Set<DbDsiWireThroughNode>();
        public DbSet<DbRfqNprRequestModel> RfqNprRequest => Set<DbRfqNprRequestModel>();
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
