namespace DSI.Data.Configuration
{

    public class DbHarnessConfiguration : IEntityTypeConfiguration<DbHarness>
    {
        public void Configure(EntityTypeBuilder<DbHarness> builder)
        {
            builder.ToTable("Harness");
            builder.HasKey(x => x.Id);
        }
    }
 }
