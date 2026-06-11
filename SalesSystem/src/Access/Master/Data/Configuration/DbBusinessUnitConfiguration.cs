namespace Master.Data.Configuration
{
    public class DbBusinessUnitConfiguration : IEntityTypeConfiguration<DbBusinessUnit>
    {
        public void Configure(EntityTypeBuilder<DbBusinessUnit> builder)
        {
            builder.ToTable("BusinessUnit", "dbo");

            builder.HasKey(x => x.Id);
        }
    }
}