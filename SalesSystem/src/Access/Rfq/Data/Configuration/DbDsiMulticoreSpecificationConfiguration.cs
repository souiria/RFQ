namespace Rfq.Data.Configuration
{
    public class DbDsiMulticoreSpecificationConfiguration : IEntityTypeConfiguration<DbDsiMulticoreSpecification>
    {
        public void Configure(EntityTypeBuilder<DbDsiMulticoreSpecification> builder)
        {
            builder.ToTable("DsiMulticoreSpecification");
            builder.HasKey(x => x.RowId);
        }
    }
}
