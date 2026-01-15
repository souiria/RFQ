namespace Purchasing.Data.Interface
{
    public interface IPurchasingDbContext
    {
        DbSet<DbH1CPD> DbH1CPD
        { get; }
    }
}
