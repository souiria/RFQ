namespace CDb.Data.Configuration
{
    public class DbComponentConfiguration : IEntityTypeConfiguration<DbComponent>
    {
        public void Configure(EntityTypeBuilder<DbComponent> builder)
        {
            builder.UseTpcMappingStrategy();

            builder.HasKey(x => x.Id);
            builder.HasIndex(c => c.SheetNumber)
                .IsUnique();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.Property(c => c.ComponentStatus)
                .IsRequired();

            builder.Property(c => c.Weight)
                .HasPrecision(8, 1);

            builder
                .HasMany(c => c.ReplacedComponents)
                .WithMany()
                .UsingEntity(j => j.ToTable("ComponentReplacements"));

            builder
                .HasMany(c => c.FileNames)
                .WithMany(f => f.Components)
                .UsingEntity(j => j.ToTable("ComponentFileNames"));

            builder
                .HasMany(c => c.Contacts)
                .WithMany(c => c.Components)
                .UsingEntity(j => j.ToTable("ComponentContacts"));

            builder
                .HasMany(c => c.Partners)
                .WithMany(p => p.Components)
                .UsingEntity(j => j.ToTable("ComponentPartners"));

            builder
                .HasMany(c => c.Tags)
                .WithMany(t => t.Components)
                .UsingEntity(j => j.ToTable("ComponentTags"));

            builder
                .HasMany(c => c.Children)
                .WithMany(c => c.Parents)
                .UsingEntity(j => j.ToTable("ComponentAggregation"));

            builder
                .HasOne(c => c.TemperatureRange)
                .WithMany()
                .HasForeignKey(c => c.TemperatureRangeId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
