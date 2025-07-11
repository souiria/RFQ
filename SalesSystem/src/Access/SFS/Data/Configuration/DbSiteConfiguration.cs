
namespace SFS.Data.Configuration
{
    public class DbSiteConfiguration : IEntityTypeConfiguration<DbSite>
    {
        public void Configure(EntityTypeBuilder<DbSite> builder)
        {
            builder.ToTable("tblSite");
            builder.HasKey(x => x.Id);
        }
    }
}
