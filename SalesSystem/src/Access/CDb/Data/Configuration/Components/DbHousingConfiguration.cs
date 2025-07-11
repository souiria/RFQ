using CDb.Data.Model.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Components
{
    public class DbHousingConfiguration : IEntityTypeConfiguration<DbHousing>
    {
        public void Configure(EntityTypeBuilder<DbHousing> builder)
        {
            builder.ToTable("Housings");
            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder
                .Property(c => c.RowCount)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}
