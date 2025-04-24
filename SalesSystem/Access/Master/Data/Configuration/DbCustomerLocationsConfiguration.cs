using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbCustomerLocationsConfiguration : IEntityTypeConfiguration<DbCustomerLocations>
    {
        public void Configure(EntityTypeBuilder<DbCustomerLocations> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
