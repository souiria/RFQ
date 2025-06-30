namespace Emacs.Data.Configuration
{
    public class DbPartCategoryDetailsConfiguration : IEntityTypeConfiguration<DbPartCategoryDetail>
    {
        public void Configure(EntityTypeBuilder<DbPartCategoryDetail> builder)
        {
            builder.Property(x => x.CategoryCode).HasColumnName("Category Code");
            builder.Property(x => x.DetailedCategoryCode).HasColumnName("Detailed Category Code");
            builder.Property(x => x.CategoryName).HasColumnName("Category Name");
            builder.ToTable("PartCategoryDetail");
            builder.HasNoKey();
        }
    }
}
