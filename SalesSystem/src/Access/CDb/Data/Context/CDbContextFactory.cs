using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CDb.Data.Context
{
    public class CDbContextFactory : IDesignTimeDbContextFactory<CDbContext>
    {
        public CDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CDbContext> optionsBuilder = new DbContextOptionsBuilder<CDbContext>();
            optionsBuilder.UseSqlServer("Server=rodvpc305.sews-e.com;Database=H1.Cdb2;User Id=dbdevusr;Password=Am9s4T8IbYntf6u7SX655csPwVV9hMqHSIkFG8VQWK3epsJryeScHoare9UAUlv;MultipleActiveResultSets=true;Encrypt=Yes;TrustServerCertificate=True");
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
            );
            CDbContext context = new CDbContext(optionsBuilder.Options, null);
            return context;
        }
    }
}
