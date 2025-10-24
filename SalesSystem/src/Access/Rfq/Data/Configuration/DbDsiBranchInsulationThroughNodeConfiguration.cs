
namespace Rfq.Data.Configuration
{
    public class DbDsiBranchInsulationThroughNodeConfiguration : IEntityTypeConfiguration<DbDsiBranchInsulationThroughNode>
    {
        public void Configure(EntityTypeBuilder<DbDsiBranchInsulationThroughNode> builder)
        {
            builder.ToTable("DsiBranchInsulationThroughNode");
            builder.HasKey(x => x.RowId);
        }
    }
}
