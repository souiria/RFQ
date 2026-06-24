namespace DSI.Data.Configuration
{

    public class DbHarnessConfiguration : IEntityTypeConfiguration<DbHarness>
    {
        public void Configure(EntityTypeBuilder<DbHarness> builder)
        {
            builder.ToTable("DsiHarness");
            builder.HasKey(x => x.HarnessId);
        }
    }
 }
