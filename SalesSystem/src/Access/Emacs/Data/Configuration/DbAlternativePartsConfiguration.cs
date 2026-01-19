
namespace Emacs.Data.Configuration
{
    public class DbAlternativePartsConfiguration : IEntityTypeConfiguration<DbAlternativeParts>
    {
        public void Configure(EntityTypeBuilder<DbAlternativeParts> builder)
        {
            builder.ToTable("vw_Alternative_Parts");
            builder.Property(x => x.CategoryCode).HasColumnName("Category Code");
            builder.Property(x => x.DetailedCategoryCode).HasColumnName("Detailed Category Code");
            builder.Property(x => x.CategoryName).HasColumnName("Category Name");
            builder.Property(x => x.PartGroupCode).HasColumnName("Part Group Code");
            builder.Property(x => x.CategoryCode2).HasColumnName("CategoryCode");
            builder.HasNoKey();
        }
    }
}
