namespace CDb.Data.Configuration.Components
{
    public class DbCoverConfiguration : IEntityTypeConfiguration<DbCover>
    {
        public void Configure(EntityTypeBuilder<DbCover> builder)
        {
            builder.ToTable("Covers");
            builder
                .HasOne(c => c.CoverType)
                .WithMany()
                .HasForeignKey(c => c.CoverTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.Width)
                .IsRequired()
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(8,1)");

            builder.Property(c => c.Length)
                .IsRequired()
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(8,1)");

            builder
                .Property(c => c.IsNoiseDampening)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(c => c.IsTearable)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(c => c.IsPreCut)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
