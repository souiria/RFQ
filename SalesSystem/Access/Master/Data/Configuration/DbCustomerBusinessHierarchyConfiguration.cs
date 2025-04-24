using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbCustomerBusinessHierarchyConfiguration : IEntityTypeConfiguration<DbCustomerBusinessHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbCustomerBusinessHierarchy> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
