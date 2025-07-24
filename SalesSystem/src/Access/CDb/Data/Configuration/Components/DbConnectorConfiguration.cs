namespace CDb.Data.Configuration.Components
{
    public class DbConnectorConfiguration : IEntityTypeConfiguration<DbConnector>
    {
        public void Configure(EntityTypeBuilder<DbConnector> builder)
        {
            builder.ToTable("Connectors");
            builder
                .HasOne(c => c.WaterproofType)
                .WithMany()
                .HasForeignKey(c => c.WaterproofTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.TerminalFamily)
                .WithMany()
                .HasForeignKey(c => c.TerminalFamilyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.TerminalSize)
                .WithMany()
                .HasForeignKey(c => c.TerminalSizeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.MatingType)
                .IsRequired()
                .HasDefaultValue(MatingType.Unknown);

            builder.Property(c => c.CavitySize)
                .IsRequired()
                .HasColumnType("decimal(8,1)");

            builder.Property(c => c.CavityCount)
                .IsRequired()
                .HasDefaultValue(1);

            builder
                .Property(c => c.IsHybrid)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(c => c.IsModule)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
