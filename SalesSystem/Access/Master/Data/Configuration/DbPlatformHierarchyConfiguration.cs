using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbPlatformHierarchyConfiguration : IEntityTypeConfiguration<DbPlatformHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbPlatformHierarchy> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
