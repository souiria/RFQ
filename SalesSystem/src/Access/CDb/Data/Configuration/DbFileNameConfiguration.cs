using CDb.Data.Model;

namespace CDb.Data.Configuration
{
    public class DbFileNameConfiguration : IEntityTypeConfiguration<DbFileName>
    {
        public void Configure(EntityTypeBuilder<DbFileName> builder)
        {
            builder.ToTable("FileNames");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(1024);
            builder.HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}
