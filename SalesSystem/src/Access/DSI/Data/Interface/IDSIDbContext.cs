namespace DSI.Data.Interface
{
    public interface IDSIDbContext
    {
        DbSet<DbBranchInsulation> DSIBranchInsulation
        { get; }
        DbSet<DbComponent> DSIComponent
        { get; }
        DbSet<DbCompositeDetail> DSICompositeDetail
        { get; }
        DbSet<DbHarness> DSIHarness
        { get; }
        DbSet<DbWireSpecification> DsiWireSpecification
        { get; }
     
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
