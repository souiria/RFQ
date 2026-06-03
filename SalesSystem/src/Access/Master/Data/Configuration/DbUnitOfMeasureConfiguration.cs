namespace Master.Data.Configuration
{
    public class DbUnitOfMeasureConfiguration : IEntityTypeConfiguration<DbUnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<DbUnitOfMeasure> builder)
        {
            builder.ToTable("UnitOfMeasure");

            builder.HasKey(x => x.Id);
        }
    }
}
