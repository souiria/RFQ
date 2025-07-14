namespace CDb.Data.Configuration.Components
{
    public class DbSealConfiguration : IEntityTypeConfiguration<DbSeal>
    {
        public void Configure(EntityTypeBuilder<DbSeal> builder)
        {
            builder.ToTable("Seals");

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.Diameter)
                .IsRequired()
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(8,1)");

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
