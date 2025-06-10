
namespace Emacs.Data.Configuration
{
    public class DbMaterialGroupsConfiguration : IEntityTypeConfiguration<DbMaterialGroups>
    {
        public void Configure(EntityTypeBuilder<DbMaterialGroups> builder)
        {
            builder.ToTable("MaterialGroups");
            builder.HasKey(x => x.MaterialGroup);
        }
    }
}
