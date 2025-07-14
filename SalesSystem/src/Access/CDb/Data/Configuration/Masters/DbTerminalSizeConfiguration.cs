using CDb.Data.Model.Masters;

namespace CDb.Data.Configuration.Masters
{
    public class DbTerminalSizeConfiguration : IEntityTypeConfiguration<DbTerminalSize>
    {
        public void Configure(EntityTypeBuilder<DbTerminalSize> builder)
        {
            builder.ToTable("TerminalSize");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(x => x.Description)
                   .HasMaxLength(500);
            builder.HasMany(x => x.Families)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Terminals)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Connectors)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
