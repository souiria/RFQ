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

            AddSeedData(builder);
        }

        static void AddSeedData(EntityTypeBuilder<DbTemperatureRange> builder)
        {
            DbTemperatureRange tu = new DbTemperatureRange("unknown", 0, 0, false);
            DbTemperatureRange t1 = new DbTemperatureRange("T1", -10, 100, false);
            DbTemperatureRange t2 = new DbTemperatureRange("T2", -20, 85, false);
            DbTemperatureRange t3 = new DbTemperatureRange("T3", -40, 85, false);
            DbTemperatureRange t4 = new DbTemperatureRange("T4", -40, 105, false);
            DbTemperatureRange t5 = new DbTemperatureRange("T5", -55, 125, false);

            builder.HasData(
                tu,
                t1,
                t2,
                t3,
                t4,
                t5);
        }
    }
}
