namespace CDb.Data.Configuration.Components
{
    public class DbShieldConfiguration : IEntityTypeConfiguration<DbShield>
    {
        public void Configure(EntityTypeBuilder<DbShield> builder)
        {
            builder.ToTable("Shields");
            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder
                .Property(c => c.AdditionalInformation)
                .HasMaxLength(256);
            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
