using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbCustomerHierarchyConfiguration : IEntityTypeConfiguration<DbCustomerHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbCustomerHierarchy> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
