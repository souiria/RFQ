using CDb.Data.Model.Masters;

namespace CDb.Data.Configuration.Masters
{
    public class DbWaterproofTypeConfiguration : IEntityTypeConfiguration<DbWaterproofType>
    {
        public void Configure(EntityTypeBuilder<DbWaterproofType> builder)
        {
            builder.ToTable("WaterproofTypes");
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Code)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(w => w.Code)
                .IsUnique();
            builder.Property(w => w.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(w => w.IsActive)
                .IsRequired();

            AddSeedData(builder);
        }

        static void AddSeedData(EntityTypeBuilder<DbWaterproofType> builder)
        {
            DbWaterproofType typeUndefined = new DbWaterproofType("Undefined", "Undefined", true);
            DbWaterproofType typeNo = new DbWaterproofType("No", "", true);
            DbWaterproofType typeGrommet = new DbWaterproofType("Grommet", "W/P P", true);
            DbWaterproofType typeSingleSeal = new DbWaterproofType("SingleSeal", "W/P S/P", true);
            DbWaterproofType typeGel = new DbWaterproofType("Gel", "W/P GEL", true);
            DbWaterproofType typeYes = new DbWaterproofType("Yes", "W/P", true);

            builder.HasData(
                typeUndefined,
                typeNo,
                typeGrommet,
                typeSingleSeal,
                typeGel,
                typeYes
            );
        }
    }
}