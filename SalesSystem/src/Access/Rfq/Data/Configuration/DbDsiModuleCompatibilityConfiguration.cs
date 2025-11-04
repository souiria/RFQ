namespace Rfq.Data.Configuration
{
    public class DbDsiModuleCompatibilityConfiguration : IEntityTypeConfiguration<DbDsiModuleCompatibility>
    {
        public void Configure(EntityTypeBuilder<DbDsiModuleCompatibility> builder)
        {
            builder.ToTable("DsiModuleCompatibility");
            builder.HasKey(x => x.RowId);
        }
    }
}
