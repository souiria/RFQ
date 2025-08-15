
namespace CDb.Data.Context
{
    public class CDbContextFactory : IDesignTimeDbContextFactory<CDbContext>
    {
        public CDbContext CreateDbContext(string[]? args = null)
        {
            DbContextOptionsBuilder<CDbContext> optionsBuilder = new DbContextOptionsBuilder<CDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=H1.Cdb2;User Id=dbdevusr;Password=OwnhjKZqZMCY0vL;MultipleActiveResultSets=true;Encrypt=Yes;TrustServerCertificate=True");
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
            );
            CDbContext context = new CDbContext(optionsBuilder.Options, null);
            return context;
        }
    }
}
