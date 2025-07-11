using CDb.Data.Model.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration.Masters
{
    public class DbMaterialTypeConfiguration : IEntityTypeConfiguration<DbMaterialType>
    {
        public void Configure(EntityTypeBuilder<DbMaterialType> builder)
        {
            builder.ToTable("MaterialTypes");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Code)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(m => m.Code)
                .IsUnique();
            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(m => m.IsActive)
                .IsRequired();

            AddSeedData(builder);
        }

        static void AddSeedData(EntityTypeBuilder<DbMaterialType> builder)
        {
            DbMaterialType materialUnknown = new DbMaterialType("Unknown", "Unknown", false);
            DbMaterialType materialAg = new DbMaterialType("Ag", "Silver", false);
            DbMaterialType materialAl = new DbMaterialType("Al", "Aluminum", false);
            DbMaterialType materialAu = new DbMaterialType("Au", "Gold", false);
            DbMaterialType materialCu = new DbMaterialType("Cu", "Copper", false);
            DbMaterialType materialSn = new DbMaterialType("Sn", "Tin", false);
            DbMaterialType materialSteel = new DbMaterialType("Steel", "Steel", false);
            DbMaterialType materialCarbonFiber = new DbMaterialType("CarbonFiber", "CarbonFiber", false);
            DbMaterialType materialGlassFiber = new DbMaterialType("GlassFiber", "GlassFiber", false);
            DbMaterialType materialPlastic = new DbMaterialType("Plastic", "Plastic", false);

            builder.HasData(
                materialUnknown,
                materialAg,
                materialAl,
                materialAu,
                materialCu,
                materialSn,
                materialSteel,
                materialCarbonFiber,
                materialGlassFiber,
                materialPlastic
            );
        }
    }
}