namespace EngSol.Data.Configuration
{
    public class DbDerivativesConfiguration : IEntityTypeConfiguration<DbDerivatives>
    {
        public void Configure(EntityTypeBuilder<DbDerivatives> builder)
        {
            builder.ToTable("Interface_WH_EngSol_Masters_Derivative");
            builder.Property(x => x.IHSDerivativePartNumber).HasConversion<string>();
            builder.HasNoKey();
        }
    }
}
