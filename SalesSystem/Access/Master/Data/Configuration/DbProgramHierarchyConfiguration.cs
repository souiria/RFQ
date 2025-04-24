using Master.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Data.Configuration
{
    public class DbProgramHierarchyConfiguration : IEntityTypeConfiguration<DbProgramHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbProgramHierarchy> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
