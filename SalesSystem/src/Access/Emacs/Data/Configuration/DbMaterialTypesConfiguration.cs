
namespace Emacs.Data.Configuration
{
    public class DbMaterialTypesConfiguration : IEntityTypeConfiguration<DbMaterialTypes>
    {
        public void Configure(EntityTypeBuilder<DbMaterialTypes> builder)
        {
            builder.ToTable("MaterialTypes");
            builder.HasKey(x => x.MaterialType);
        }
    }
}
