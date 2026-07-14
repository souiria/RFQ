namespace CDb.Data.Configuration.Components
{
    public class DbSubAssemblyConfiguration : IEntityTypeConfiguration<DbSubAssembly>
    {
        public void Configure(EntityTypeBuilder<DbSubAssembly> builder)
        {
            builder.ToTable("SubAssemblies");

            builder
                .Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.Function)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(c => c.AdditionalInformation)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .HasOne(c => c.TerminalFamily)
                .WithMany()
                .HasForeignKey(c => c.TerminalFamilyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.TerminalSize)
                .WithMany()
                .HasForeignKey(c => c.TerminalSizeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
