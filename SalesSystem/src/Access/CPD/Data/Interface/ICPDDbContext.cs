namespace CPD.Data.Interface
{
    public interface ICPDDbContext
    {
        DbSet<DbMattSuppMstView> MattSuppMstView
        { get; }
    }
}
