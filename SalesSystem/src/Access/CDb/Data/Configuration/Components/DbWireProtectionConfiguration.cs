namespace CDb.Data.Configuration.Components
{
    public class DbWireProtectionConfiguration : IEntityTypeConfiguration<DbWireProtection>
    {
        public void Configure(EntityTypeBuilder<DbWireProtection> builder)
        {
            builder.ToTable("WireProtections");

            builder
                .HasOne(c => c.WireProtectionType)
                .WithMany()
                .HasForeignKey(c => c.WireProtectionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(c => c.TapeWidth)
                .IsRequired()
                .HasColumnType("decimal(5,1)")
                .HasDefaultValue(0.0m);

            builder.Property(c => c.TubeDiameter)
                .IsRequired()
                .HasColumnType("decimal(5,1)")
                .HasDefaultValue(0.0m);

            builder.Property(c => c.Specification)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(c => c.AdditionalInformation)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
