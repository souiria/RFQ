using Microsoft.Extensions.Configuration;

namespace CDb.Data.Context
{
    public class CDbContextFactory : IDesignTimeDbContextFactory<CDbContext>
    {
        public CDbContext CreateDbContext(string[]? args = null)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            // Build configuration to read from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Get connection string from configuration
            string connectionString = configuration.GetConnectionString("Database") 
                ?? throw new InvalidOperationException("Connection string 'Database' not found in configuration.");

            DbContextOptionsBuilder<CDbContext> optionsBuilder = new DbContextOptionsBuilder<CDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
            );
            
            CDbContext context = new CDbContext(optionsBuilder.Options, null);
            return context;
        }
    }
}
