namespace Emacs.Data.Interface
{
    public interface IEMACSDbContext
    {
        DbSet<DbCombinedParts> CombinedParts 
        { get; }
        DbSet<DbPartCategoryDetail> PartCategoryDetails
        { get; }
        DbSet<DbPartClassDetail> PartClassDetail
        { get; }
        DbSet<DbPartGroups> PartGroups
        { get; }
        DbSet<DbPartGroupsConst> PartGroupsConst
        { get; }
        DbSet<DbCustomerData> CustomerData
        { get; }
        DbSet<DbColourCode> ColourCode
        { get; }
        DbSet<DbMaterialGroups> MaterialGroups
        { get; }
        DbSet<DbMaterialTypes> MaterialTypes
        { get; }
        DbSet<DbNPACustomer> NPACustomers
        { get; }
        DbSet<DbNPASupplier> NPASuppliers
        { get; }
        DbSet<DbSuppliers> Suppliers
        { get; }
        DbSet<DbEmacsRFIView> EmacsRFIViews
        { get; }
        DbSet<DbPARTMS> DbPARTMS
        { get; }
        DbSet<DbAlternativeParts> DbAlternativeParts
        { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
