namespace Rfq.Data.Configuration
{
    public class DbDsiWireSpecificationConfiguration : IEntityTypeConfiguration<DbDsiWireSpecification>
    {
        public void Configure(EntityTypeBuilder<DbDsiWireSpecification> builder)
        {
            builder.ToTable("DsiWireSpecification");
            builder.HasKey(x => x.RowId);
        }
    }
}
