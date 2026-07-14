namespace Rfq.Data.Configuration
{
    public class DbDsiComponentConfiguration : IEntityTypeConfiguration<DbDsiComponent>
    {
        public void Configure(EntityTypeBuilder<DbDsiComponent> builder)
        {
            builder.ToTable("DsiComponent");
            builder.HasKey(x => x.RowId);
        }
    }
}
