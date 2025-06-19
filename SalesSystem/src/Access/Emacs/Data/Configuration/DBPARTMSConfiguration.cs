
namespace Emacs.Data.Configuration
{
    public class DBPARTMSConfiguration : IEntityTypeConfiguration<DbPARTMS>
    {
        public void Configure(EntityTypeBuilder<DbPARTMS> builder)
        {
            builder.ToTable("PARTMS");
            builder.HasNoKey();
        }
    }
}
