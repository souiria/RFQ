
namespace Rfq.Data.Configuration
{
    public class DbDsiBranchConfigurationConfiguration : IEntityTypeConfiguration<DbDsiBranchConfiguration>
    {
        public void Configure(EntityTypeBuilder<DbDsiBranchConfiguration> builder)
        {
            builder.ToTable("DsiBranchConfiguration");
            builder.HasKey(x => x.RowId);
        }
    }
}
