using SFS.Data.DTOs;

namespace SFS.Data.Configuration
{
    public class DailyVolumeDataDtoConfiguration : IEntityTypeConfiguration<DbDailyVolumeData>
    {
        public void Configure(EntityTypeBuilder<DbDailyVolumeData> builder)
        {
            builder.HasNoKey();
            builder.ToTable("tblPropImp");  
        }
    }
}
