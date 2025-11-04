namespace Rfq.Data.Configuration
{
    public class DbDsiCentreStripConfiguration : IEntityTypeConfiguration<DbDsiCentreStrip>
    {
        public void Configure(EntityTypeBuilder<DbDsiCentreStrip> builder)
        {
            builder.ToTable("DsiCentreStrip");
            builder.HasKey(x => x.RowId);
        }
    }
}
