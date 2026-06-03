namespace Master.Data.Interface
{
    public interface IMastersDbContext
    {
        DbSet<DbCurrency> CurrencyItems
        { get; }
        DbSet<DbCustomerBusinessHierarchy> CustomerBusinessUnitItems
        { get; }
        DbSet<DbCustomerBusinessUserAssociation> CustomerBusinessUserAssociationItems
        { get; }
        DbSet<DbCustomerHierarchy> CustomerLocationItems
        { get; }
        DbSet<DbCustomerProjectAssociation> CustomerProjectAssociationItems
        { get; }
        DbSet<DbCustomerSalesEntity> CustomerSalesEntityItems
        { get; }
        DbSet<DbMilestoneHierarchy> MilestoneHierarchyItems
        { get; }
        DbSet<DbPlatformHierarchy> PlatformItems
        { get; }
        DbSet<DbProgramHierarchy> ProgramItems
        { get; }
        DbSet<DbProjectHierarchy> ProjectItems
        { get; }
        DbSet<DbVehicle> VehicleItems
        { get; }
        DbSet<DbSupplierGroup> SupplierGroup
        { get; }
        DbSet<DbSupplier> Supplier
        { get; }
         DbSet<DbUnitOfMeasure> UnitOfMeasures
         { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
