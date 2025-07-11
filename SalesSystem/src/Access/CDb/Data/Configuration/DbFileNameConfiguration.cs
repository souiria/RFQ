using CDb.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
