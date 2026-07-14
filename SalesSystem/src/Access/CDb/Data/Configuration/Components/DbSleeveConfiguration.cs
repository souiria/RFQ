namespace CDb.Data.Configuration.Components
{
    public class DbSleeveConfiguration : IEntityTypeConfiguration<DbSleeve>
    {
        public void Configure(EntityTypeBuilder<DbSleeve> builder)
        {
            builder.ToTable("Sleeves");

            builder
                .HasOne(c => c.WaterproofType)
                .WithMany()
                .HasForeignKey(c => c.WaterproofTypeId)
                .OnDelete(DeleteBehavior.NoAction);

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
                .Property(c => c.Length)
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
