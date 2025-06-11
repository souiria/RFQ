namespace Emacs.Data.Configuration
{
    public class DbPartClassDetailConfiguration : IEntityTypeConfiguration<DbPartClassDetail>
    {
        public void Configure(EntityTypeBuilder<DbPartClassDetail> builder)
        {
            builder.ToTable("PartClassDetail");
            builder.HasNoKey();
        }
    }
}
