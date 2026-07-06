namespace EngSol.Data.Interface
{
    public interface IEngSolDbContext
    {
        DbSet<DbDerivativeWires> DerivativeWires
        { get; }
        DbSet<DbDerivativeParts> DerivativeParts
        { get; }
        DbSet<DbDerivatives> Derivatives
        { get; }
    }
}
