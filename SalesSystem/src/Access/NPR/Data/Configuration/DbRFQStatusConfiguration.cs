namespace NPR.Data.Configuration
{
    public class DbRFQStatusConfiguration : IEntityTypeConfiguration<DbRFQStatus>
    {
        public void Configure(EntityTypeBuilder<DbRFQStatus> builder)
        {
            builder.ToTable("RFQStatus");
            builder.HasNoKey();
        }
    }
}
