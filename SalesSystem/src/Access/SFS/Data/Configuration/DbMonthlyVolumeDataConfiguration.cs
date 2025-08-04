namespace SFS.Data.Configuration
{
    public class DbMonthlyVolumeDataConfiguration : IEntityTypeConfiguration<DbMonthlyVolumeData>
    {
        public void Configure(EntityTypeBuilder<DbMonthlyVolumeData> builder)
        {
            builder.HasNoKey();
            builder.ToView("MonthlyVolumeDataView"); 
        }
    }
}
