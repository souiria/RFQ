
namespace SFS.Data.Configuration
{
    public class DbPeriodConfiguration : IEntityTypeConfiguration<DbPeriod>
    {
        public void Configure(EntityTypeBuilder<DbPeriod> builder)
        {
            builder.ToTable("tblPeriod");
            builder.HasKey(x => x.Id);
        }
    }
}
