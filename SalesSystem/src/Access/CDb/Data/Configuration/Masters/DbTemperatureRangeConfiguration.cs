using CDb.Data.Model.Masters;

namespace CDb.Data.Configuration.Masters
{
    public class DbTemperatureRangeConfiguration : IEntityTypeConfiguration<DbTemperatureRange>
    {
        public void Configure(EntityTypeBuilder<DbTemperatureRange> builder)
        {
            builder.ToTable("TemperatureRanges");
            builder.HasKey(x => x.Id);

            builder.HasMany(tr => tr.Components)
               .WithOne(c => c.TemperatureRange)
               .HasForeignKey(c => c.TemperatureRangeId);
        }
    }
}
