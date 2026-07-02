namespace EngSol.Data.Configuration
{
    public class DbDerivativePartsConfiguration : IEntityTypeConfiguration<DbDerivativeParts>
    {
        public void Configure(EntityTypeBuilder<DbDerivativeParts> builder)
        {
            builder.ToTable("Interface_WH_EngSol_Derivative_Part");
            builder.HasNoKey();
        }
    }
}
