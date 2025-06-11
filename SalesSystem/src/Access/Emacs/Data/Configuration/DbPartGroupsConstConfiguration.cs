
namespace Emacs.Data.Configuration
{
    public class DbPartGroupsConstConfiguration : IEntityTypeConfiguration<DbPartGroupsConst>
    {
        public void Configure(EntityTypeBuilder<DbPartGroupsConst> builder)
        {
            builder.ToTable("PartGroupsConst");
            builder.HasKey(x => x.Id);
        }
    }
}
