namespace CDb.Data.Configuration.Masters
{
    public class DbTerminalFamilyConfiguration : IEntityTypeConfiguration<DbTerminalFamily>
    {
        public void Configure(EntityTypeBuilder<DbTerminalFamily> builder)
        {
            builder.ToTable("TerminalFamilies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
            
            builder
                .HasMany(x => x.Terminals)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Connectors)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Description)
                .HasMaxLength(256);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(false);

        }
    }
}
