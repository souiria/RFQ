namespace SFS.Data.Configuration
{
    public class DbCalculationTypeConfiguration : IEntityTypeConfiguration<DbCalculationType>
    {
        public void Configure(EntityTypeBuilder<DbCalculationType> builder)
        {
            builder.HasNoKey();
            builder.ToView("CalculationType_view");
        }
    }
}
