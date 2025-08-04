namespace CDb.Data.Configuration.Components
{
    public class DbClipConfiguration : IEntityTypeConfiguration<DbClip>
    {
        public void Configure(EntityTypeBuilder<DbClip> builder)
        {
            builder.ToTable("Clips");
            builder
                .HasOne(c => c.ClipType)
                .WithMany()
                .HasForeignKey(c => c.ClipTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.Length)
                .IsRequired()
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(8, 1)");

            builder.Property(c => c.TieType)
                .IsRequired();

            builder.Property(c => c.DimensionCode)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(c => c.ClipOrientationStart)
                .IsRequired();

            builder.Property(c => c.ClipOrientationEnd)
                .IsRequired();

            builder.Property(c => c.ThicknessCode)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
