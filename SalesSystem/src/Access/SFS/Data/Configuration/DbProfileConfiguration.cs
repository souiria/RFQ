
namespace SFS.Data.Configuration
{
    public class DbProfileConfiguration : IEntityTypeConfiguration<DbProfile>
    {
        public void Configure(EntityTypeBuilder<DbProfile> builder)
        {
            builder.ToTable("tblProfile");
            builder.HasKey(x => x.Id);
        }
    }
}
