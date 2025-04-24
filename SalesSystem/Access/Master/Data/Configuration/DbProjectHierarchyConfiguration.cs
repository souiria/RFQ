using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbProjectHierarchyConfiguration : IEntityTypeConfiguration<DbProjectHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbProjectHierarchy> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
