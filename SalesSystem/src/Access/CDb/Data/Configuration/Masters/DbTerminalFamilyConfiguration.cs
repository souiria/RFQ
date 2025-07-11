using CDb.Data.Model.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            
            builder.Property(x => x.Description)
                .HasMaxLength(256);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
