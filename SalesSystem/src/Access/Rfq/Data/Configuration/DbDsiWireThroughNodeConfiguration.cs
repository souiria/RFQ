namespace Rfq.Data.Configuration
{
    public class DbDsiWireThroughNodeConfiguration : IEntityTypeConfiguration<DbDsiWireThroughNode>
    {
        public void Configure(EntityTypeBuilder<DbDsiWireThroughNode> builder)
        {
            builder.ToTable("DsiWireThroughNode");
            builder.HasKey(x => x.RowId);
        }
    }
}
