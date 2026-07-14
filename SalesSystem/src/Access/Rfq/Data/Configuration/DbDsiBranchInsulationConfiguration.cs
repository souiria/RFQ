
namespace Rfq.Data.Configuration
{
    public class DbDsiBranchInsulationConfiguration : IEntityTypeConfiguration<DbDsiBranchInsulation>
    {
        public void Configure(EntityTypeBuilder<DbDsiBranchInsulation> builder)
        {
            builder.ToTable("DsiBranchInsulation");
            builder.HasKey(x => x.RowId);
        }
    }
}
