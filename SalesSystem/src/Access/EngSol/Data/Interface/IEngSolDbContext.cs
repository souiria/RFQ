namespace EngSol.Data.Interface
{
    public interface IEngSolDbContext
    {
        DbSet<DbDerivativeWires> DerivativeWires
        { get; }
    }
}
