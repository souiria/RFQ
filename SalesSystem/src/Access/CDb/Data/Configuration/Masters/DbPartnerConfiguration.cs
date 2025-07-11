using CDb.Data.Model.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Masters
{
    public class DbPartnerConfiguration : IEntityTypeConfiguration<DbPartner>
    {
        public void Configure(EntityTypeBuilder<DbPartner> builder)
        {
            builder.ToTable("Partners");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.PartnerType)
                .IsRequired();
            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.HasIndex(p => p.Code);
            builder.HasIndex(p => p.Name);

            builder.HasIndex(p => new { p.PartnerType, p.Code, p.Name })
                .IsUnique();
        }
    }
}
