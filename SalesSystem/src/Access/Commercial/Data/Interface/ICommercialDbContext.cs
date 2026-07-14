namespace Commercial.Data.Interface
{
    public interface ICommercialDbContext
    {
        DbSet<DbPurchaseOrder> PurchaseOrders
        { get; }
    }
}
