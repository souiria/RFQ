namespace CDb.Data.Configuration.Components
{
    public class DbRelayConfiguration : IEntityTypeConfiguration<DbRelay>
    {
        public void Configure(EntityTypeBuilder<DbRelay> builder)
        {
            builder.ToTable("Relays");

            builder
                .Property(c => c.Amperage)
                .IsRequired()
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(8,1)");

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.Specification)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
