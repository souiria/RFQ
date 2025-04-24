using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbVehicleConfiguration : IEntityTypeConfiguration<DbVehicle>
    {
        public void Configure(EntityTypeBuilder<DbVehicle> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
