namespace CDb.Data.Configuration.Components
{
    public class DbFuseConfiguration : IEntityTypeConfiguration<DbFuse>
    {
        public void Configure(EntityTypeBuilder<DbFuse> builder)
        {
            builder.ToTable("Fuses");
            builder
                .HasOne(c => c.FuseType)
                .WithMany()
                .HasForeignKey(c => c.FuseTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.Amperage)
                .IsRequired()
                .HasDefaultValue(0.0m);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.AdditionalInformation)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
