namespace EngSol.Data.Configuration
{
    public class DbDerivativeWiresConfiguration : IEntityTypeConfiguration<DbDerivativeWires>
    {
        public void Configure(EntityTypeBuilder<DbDerivativeWires> builder)
        {
            builder.ToTable("Interface_WH_EngSol_Derivative_Wire");
            builder.Property(x => x.EndA).HasConversion<string>();
            builder.HasNoKey();
        }
    }
}
