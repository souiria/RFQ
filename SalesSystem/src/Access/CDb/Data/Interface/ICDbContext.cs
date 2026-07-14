namespace CDb.Data.Interface
{
    public interface ICDbContext
    {
        DbSet<DbAuditEvent> AuditEvents
        { get; set; }
        DbSet<DbCable> Cables
        { get; set; }
        DbSet<DbClip> Clips
        { get; set; }
        DbSet<DbClipType> ClipTypes
        { get; set; }
        DbSet<DbComponent> Components
        { get; set; }
        DbSet<DbConnector> Connectors
        { get; set; }
        DbSet<DbCover> Covers
        { get; set; }
        DbSet<DbCoverType> CoverTypes
        { get; set; }
        DbSet<DbCrimpingProcessType> CrimpingProcessTypes
        { get; set; }
        DbSet<DbDiode> Diodes
        { get; set; }
        DbSet<DbEyelet> Eyelets
        { get; set; }
        DbSet<DbFileName> FileNames
        { get; set; }
        DbSet<DbFileType> FileTypes
        { get; set; }
        DbSet<DbFuse> Fuses
        { get; set; }
        DbSet<DbFuseType> FuseTypes
        { get; set; }
        DbSet<DbGrommet> Grommets
        { get; set; }
        DbSet<DbHousing> Housings
        { get; set; }
        DbSet<DbMaterialType> MaterialTypes
        { get; set; }
        DbSet<DbMiscellaneousComponent> MiscellaneousComponents
        { get; set; }
        DbSet<DbMiscellaneousComponentType> MiscellaneousComponentTypes
        { get; set; }
        DbSet<DbPartner> Partners
        { get; set; }
        DbSet<DbPartNumber> PartNumbers
        { get; set; }
        DbSet<DbPerson> Persons
        { get; set; }
        DbSet<DbPlug> Plugs
        { get; set; }
        DbSet<DbRelay> Relays
        { get; set; }
        DbSet<DbSeal> Seals
        { get; set; }
        DbSet<DbShield> Shields
        { get; set; }
        DbSet<DbSleeve> Sleeves
        { get; set; }
        DbSet<DbSubAssembly> SubAssemblys
        { get; set; }
        DbSet<DbSupport> Supports
        { get; set; }
        DbSet<DbTag> Tags
        { get; set; }
        DbSet<DbTemperatureRange> TemperatureRanges
        { get; set; }
        DbSet<DbTerminalFamily> TerminalFamilys
        { get; set; }
        DbSet<DbTerminal> Terminals
        { get; set; }
        DbSet<DbTerminalSize> TerminalSizes
        { get; set; }
        DbSet<DbTypeCode> TypeCodes
        { get; set; }
        DbSet<DbWaterproofType> WaterproofTypes
        { get; set; }
        DbSet<DbWireProtection> WireProtections
        { get; set; }
        DbSet<DbWireProtectionType> WireProtectionTypes
        { get; set; }
        DbSet<DbWire> Wires
        { get; set; }
        DbSet<DbWireType> WireTypes
        { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}