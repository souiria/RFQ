using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbMilestoneHierarchyConfiguration : IEntityTypeConfiguration<DbMilestoneHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbMilestoneHierarchy> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
