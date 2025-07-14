namespace CDb.Data.Configuration.Components
{
    public class DbTerminalConfiguration : IEntityTypeConfiguration<DbTerminal>
    {
        public void Configure(EntityTypeBuilder<DbTerminal> builder)
        {
            builder.ToTable("Terminals");

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

            builder
                .HasOne(c => c.WireType)
                .WithMany()
                .HasForeignKey(c => c.WireTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.MatingType)
                .IsRequired()
                .HasDefaultValue(MatingType.Unknown);

            builder.Property(c => c.AdditionalInformation)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(c => c.PlatingType)
                .IsRequired()
                .HasDefaultValue(PlatingType.SN);
        }
    }
}
