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
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
