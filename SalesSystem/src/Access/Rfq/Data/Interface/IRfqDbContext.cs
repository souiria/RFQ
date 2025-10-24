namespace Rfq.Data.Interface
{
    public interface IRfqDbContext
    {
        DbSet<DbRfqDrawingPartNumber> RfqDrawingPartNumber
        { get; }
        DbSet<DbRfqProject> RfqProject
        { get; }
        DbSet<DbRfqNotes> RfqNotes
        { get; }
        DbSet<DbRfqReason> RfqReason
        { get; }
        DbSet<DbDsiBend> DsiBend
        { get; }
        DbSet<DbDsiBranchConfiguration> DsiBranchConfiguration
        { get; }
        DbSet<DbDsiBranchConfigurationBendAssociation> DsiBranchConfigurationBendAssociation
        { get; }
        DbSet<DbDsiBranchInsulation> DsiBranchInsulation
        { get; }
        DbSet<DbDsiBranchInsulationThroughNode> DsiBranchInsulationThroughNode
        { get; }
        DbSet<DbDsiCavityMapping> DsiCavityMapping
        { get; }
        DbSet<DbDsiCentreStrip> DsiCentreStrip
        { get; }
        DbSet<DbDsiComponent> DsiComponent 
        { get; }
        DbSet<DbDsiCompositeDetail> DsiCompositeDetail 
        { get; }
        DbSet<DbDsiCompositeDetailCircuitOptionAssociation> DsiCompositeDetailCircuitOptionAssociation 
        { get; }
        DbSet<DbDsiCompositeOption> DsiCompositeOption 
        { get; }
        DbSet<DbDsiHarness> DsiHarness 
        { get; }
        DbSet<DbDsiHarnessScope> DsiHarnessScope
        { get; }
        DbSet<DbDsiHarnessScopeScopeAssociation> DsiHarnessScopeScopeAssociation
        { get; }
        DbSet<DbDsiManualBomQuantity> DsiManualBomQuantity 
        { get; }
        DbSet<DbDsiMidWireComponent> DsiMidWireComponent 
        { get; }
        DbSet<DbDsiModuleChildDetail> DsiModuleChildDetail 
        { get; }
        DbSet<DbDsiModuleCompatibility> DsiModuleCompatibility 
        { get; }
        DbSet<DbDsiMulticoreSpecification> DsiMulticoreSpecification
        { get; }
        DbSet<DbDsiPinMapping> DsiPinMapping
        { get; }
        DbSet<DbDsiPinMappingCavityMappingAssociation> DsiPinMappingCavityMappingAssociation
        { get; }
        DbSet<DbDsiScope> DsiScope
        { get; }
        DbSet<DbDsiSupplier> DsiSupplier
        { get; }
        DbSet<DbDsiTransformedCompositeDetail> DsiTransformedCompositeDetail
        { get; }
        DbSet<DbDsiTransformedHarness> DsiTransformedHarness 
        { get; }
        DbSet<DbDsiTransformedModuleChildDetail> DsiTransformedModuleChildDetail 
        { get; }
        DbSet<DbDsiUnitOfMeasure> DsiUnitOfMeasure 
        { get; }
        DbSet<DbDsiWireMulticoreMarker> DsiWireMulticoreMarker
        { get; }
        DbSet<DbDsiWireSpecification> DsiWireSpecification 
        { get; }
        DbSet<DbDsiWireThroughNode> DsiWireThroughNode
        { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
