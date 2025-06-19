
namespace Emacs.Data.Configuration
{
    public class DbEmacsRFIViewConfiguration : IEntityTypeConfiguration<DbEmacsRFIView>
    {
        public void Configure(EntityTypeBuilder<DbEmacsRFIView> builder)
        {
            builder.ToTable("EmacsRFIView");
            builder.HasNoKey();
        }
    }
}
