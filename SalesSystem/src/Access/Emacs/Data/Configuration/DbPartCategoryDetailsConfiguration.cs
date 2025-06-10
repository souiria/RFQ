namespace Emacs.Data.Configuration
{
    public class DbPartCategoryDetailsConfiguration : IEntityTypeConfiguration<DbPartCategoryDetail>
    {
        public void Configure(EntityTypeBuilder<DbPartCategoryDetail> builder)
        {
            builder.ToTable("PartCategoryDetail");
            builder.HasNoKey();
        }
    }
}
