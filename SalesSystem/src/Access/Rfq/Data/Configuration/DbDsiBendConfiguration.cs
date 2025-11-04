namespace Rfq.Data.Configuration
{
    public class DbDsiBendConfiguration : IEntityTypeConfiguration<DbDsiBend>
    {
        public void Configure(EntityTypeBuilder<DbDsiBend> builder)
        {
            builder.ToTable("DsiBend");
            builder.HasKey(x => x.RowId);
        }
    }
}
