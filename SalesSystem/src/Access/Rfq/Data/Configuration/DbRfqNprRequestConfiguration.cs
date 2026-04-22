namespace Rfq.Data.Configuration
{
    public class DbRfqNprRequestConfiguration : IEntityTypeConfiguration<DbRfqNprRequestModel>
    {
        public void Configure(EntityTypeBuilder<DbRfqNprRequestModel> builder)
        {
            builder.ToTable("RfqNprRequest");
            builder.HasKey(x => x.Id);
            // Configure SampleSiteDetails as owned entity collection stored in JSON column
            builder.OwnsMany(
                e => e.SampleSiteDetails,
                navigationBuilder =>
                {
                    navigationBuilder.ToJson();

                    navigationBuilder.Property(s => s.BusinessUnitCode)
                        .HasMaxLength(4)
                        .IsUnicode(true);

                    navigationBuilder.Property(s => s.SendSampleContactPersonName)
                        .HasMaxLength(100)
                        .IsUnicode(true);
                });
        }
    }
}
