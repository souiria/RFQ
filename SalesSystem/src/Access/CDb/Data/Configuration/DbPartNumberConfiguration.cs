namespace CDb.Data.Configuration
{
    public class DbPartNumberConfiguration : IEntityTypeConfiguration<DbPartNumber>
    {
        public void Configure(EntityTypeBuilder<DbPartNumber> builder)
        {
            builder.ToTable("PartNumbers");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.PartNumberType)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.HasOne(x => x.Component)
                .WithMany(x => x.PartNumbers)
                .HasForeignKey(x => x.ComponentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
