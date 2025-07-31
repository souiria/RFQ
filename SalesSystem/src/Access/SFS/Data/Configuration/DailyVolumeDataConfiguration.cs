namespace SFS.Data.Configuration
{
    public class DailyVolumeDataConfiguration : IEntityTypeConfiguration<DbDailyVolumeData>
    {
        public void Configure(EntityTypeBuilder<DbDailyVolumeData> builder)
        {
            builder.HasNoKey();
            builder.ToTable("tblPropImp");  
        }
    }
}
