
namespace Emacs.Data.Configuration
{
    public class DbPartGroupsConfiguration : IEntityTypeConfiguration<DbPartGroups>
    {
        public void Configure(EntityTypeBuilder<DbPartGroups> builder)
        {
            builder.ToTable("PartGroups");
            builder.HasKey(x => x.PartGroup);
        }
    }
}
