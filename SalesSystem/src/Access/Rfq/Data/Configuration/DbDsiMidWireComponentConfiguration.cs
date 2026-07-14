namespace Rfq.Data.Configuration
{
    public class DbDsiMidWireComponentConfiguration : IEntityTypeConfiguration<DbDsiMidWireComponent>
    {
        public void Configure(EntityTypeBuilder<DbDsiMidWireComponent> builder)
        {
            builder.ToTable("DsiMidWireComponent");
            builder.HasKey(x => x.RowId);
        }
    }
}
