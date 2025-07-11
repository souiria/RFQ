namespace SFS.Data.Configuration
{
    public class DbCarModelConfiguration : IEntityTypeConfiguration<DbCarModel>
    {
        public void Configure(EntityTypeBuilder<DbCarModel> builder)
        {
            builder.ToTable("tblCarModel");
            builder.HasKey(x => x.Id);
        }
    }
}
