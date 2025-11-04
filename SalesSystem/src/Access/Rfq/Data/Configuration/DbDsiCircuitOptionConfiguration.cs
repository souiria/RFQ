namespace Rfq.Data.Configuration
{
    public class DbDsiCircuitOptionConfiguration : IEntityTypeConfiguration<DbDsiCircuitOption>
    {
        public void Configure(EntityTypeBuilder<DbDsiCircuitOption> builder)
        {
            builder.ToTable("DsiCircuitOption");
            builder.HasKey(x => x.RowId);
        }
    }

}
