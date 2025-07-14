using CDb.Data.Model.Masters;

namespace CDb.Data.Configuration.Masters
{
    public class DbCrimpingProcessTypeConfiguration : IEntityTypeConfiguration<DbCrimpingProcessType>
    {
        public void Configure(EntityTypeBuilder<DbCrimpingProcessType> builder)
        {
            builder.ToTable("CrimpingProcessTypes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(c => c.Code)
                .IsUnique();
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(c => c.IsActive)
                .IsRequired();

            AddSeedData(builder);
        }

        static void AddSeedData(EntityTypeBuilder<DbCrimpingProcessType> builder)
        {
            DbCrimpingProcessType typeUnknown = new DbCrimpingProcessType("Unknown", "Unknown", false);
            DbCrimpingProcessType typeOpenBarrel = new DbCrimpingProcessType("OpenBarrel", "Open barrel", false);
            DbCrimpingProcessType typeTubularBarrel = new DbCrimpingProcessType("TubularBarrel", "Tubular barrel", false);
            DbCrimpingProcessType typeUsw = new DbCrimpingProcessType("Usw", "USW", false);

            builder.HasData(
                typeUnknown,
                typeOpenBarrel,
                typeTubularBarrel,
                typeUsw
            );
        }
    }
}