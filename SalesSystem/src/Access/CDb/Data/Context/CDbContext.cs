namespace CDb.Data.Context
{
    public class CDbContext : DbContext, ICDbContext
    {

        readonly IDomainEventsDispatcher? _Dispatcher;
        public CDbContext(DbContextOptions<CDbContext> options, IDomainEventsDispatcher? dispatcher) : base(options)
        {
            _Dispatcher = dispatcher;
        }

        #region Masters
        public DbSet<DbClipType> ClipTypes
        { get; set; }
        public DbSet<DbCoverType> CoverTypes
        { get; set; }
        public DbSet<DbCrimpingProcessType> CrimpingProcessTypes
        { get; set; }
        public DbSet<DbFileType> FileTypes
        { get; set; }
        public DbSet<DbFuseType> FuseTypes
        { get; set; }
        public DbSet<DbMaterialType> MaterialTypes
        { get; set; }
        public DbSet<DbMiscellaneousComponentType> MiscellaneousComponentTypes
        { get; set; }
        public DbSet<DbPartner> Partners
        { get; set; }
        public DbSet<DbPerson> Persons
        { get; set; }
        public DbSet<DbTemperatureRange> TemperatureRanges
        { get; set; }
        public DbSet<DbTerminalFamily> TerminalFamilys
        { get; set; }
        public DbSet<DbTerminalSize> TerminalSizes
        { get; set; }
        public DbSet<DbTypeCode> TypeCodes
        { get; set; }
        public DbSet<DbWaterproofType> WaterproofTypes
        { get; set; }
        public DbSet<DbWireProtectionType> WireProtectionTypes
        { get; set; }
        public DbSet<DbWireType> WireTypes
        { get; set; }
        #endregion

        #region Main
        public DbSet<DbAuditEvent> AuditEvents
        { get; set; }
        public DbSet<DbComponent> Components
        { get; set; }
        public DbSet<DbFileName> FileNames
        { get; set; }
        public DbSet<DbPartNumber> PartNumbers
        { get; set; }
        public DbSet<DbTag> Tags
        { get; set; }
        #endregion

        #region Components
        public DbSet<DbCable> Cables
        { get; set; }
        public DbSet<DbClip> Clips
        { get; set; }
        public DbSet<DbConnector> Connectors
        { get; set; }
        public DbSet<DbCover> Covers
        { get; set; }
        public DbSet<DbDiode> Diodes
        { get; set; }
        public DbSet<DbEyelet> Eyelets
        { get; set; }
        public DbSet<DbFuse> Fuses
        { get; set; }
        public DbSet<DbGrommet> Grommets
        { get; set; }
        public DbSet<DbHousing> Housings
        { get; set; }
        public DbSet<DbMiscellaneousComponent> MiscellaneousComponents
        { get; set; }
        public DbSet<DbPlug> Plugs
        { get; set; }
        public DbSet<DbRelay> Relays
        { get; set; }
        public DbSet<DbSeal> Seals
        { get; set; }
        public DbSet<DbShield> Shields
        { get; set; }
        public DbSet<DbSleeve> Sleeves
        { get; set; }
        public DbSet<DbSubAssembly> SubAssemblys
        { get; set; }
        public DbSet<DbSupport> Supports
        { get; set; }
        public DbSet<DbTerminal> Terminals
        { get; set; }
        public DbSet<DbWire> Wires
        { get; set; }
        public DbSet<DbWireProtection> WireProtections
        { get; set; }

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
