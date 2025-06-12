
namespace Emacs.Data.Configuration
{
    public class DbColourCodeConfiguration : IEntityTypeConfiguration<DbColourCode>
    {
        public void Configure(EntityTypeBuilder<DbColourCode> builder)
        {
            builder.ToTable("ColourCode");
            builder.HasKey(x => x.ClMk);
        }
    }
}
