using CDb.Data.Model;

namespace CDb.Data.Configuration
{
    public class DbTagConfiguration : IEntityTypeConfiguration<DbTag>
    {
        public void Configure(EntityTypeBuilder<DbTag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
