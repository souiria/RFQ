namespace Rfq.Data.Configuration
{
    public class DbRfqNprRequestConfiguration : IEntityTypeConfiguration<DbRfqNprRequestModel>
    {
        public void Configure(EntityTypeBuilder<DbRfqNprRequestModel> builder)
        {
            builder.ToTable("RfqNprRequest");
            builder.HasKey(x => x.Id);
        }
    }
}
