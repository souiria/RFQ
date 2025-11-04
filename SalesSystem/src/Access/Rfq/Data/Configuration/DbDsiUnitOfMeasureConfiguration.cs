namespace Rfq.Data.Configuration
{
    public class DbDsiUnitOfMeasureConfiguration : IEntityTypeConfiguration<DbDsiUnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<DbDsiUnitOfMeasure> builder)
        {
            builder.ToTable("DsiUnitOfMeasure");
            builder.HasKey(x => x.RowId);
        }
    }
}
