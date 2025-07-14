using CDb.Data.Model.Masters;

namespace CDb.Data.Configuration.Masters
{
    public class DbCoverTypeConfiguration : IEntityTypeConfiguration<DbCoverType>
    {
        public void Configure(EntityTypeBuilder<DbCoverType> builder)
        {
            builder.ToTable("CoverTypes");
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

        static void AddSeedData(EntityTypeBuilder<DbCoverType> builder)
        {
            DbCoverType coverTypeUnknown = new DbCoverType("Unknown", "Unknown", false);
            DbCoverType coverTypeType0 = new DbCoverType("Type0", "Type 0", false);
            DbCoverType coverTypeType1 = new DbCoverType("Type1", "Type 1", false);
            DbCoverType coverTypeType2 = new DbCoverType("Type2", "Type 2", false);
            DbCoverType coverTypeType3 = new DbCoverType("Type3", "Type 3", false);
            DbCoverType coverTypeType4 = new DbCoverType("Type4", "Type 4", false);

            builder.HasData(
                coverTypeUnknown,
                coverTypeType0,
                coverTypeType1,
                coverTypeType2,
                coverTypeType3,
                coverTypeType4
            );
        }
    }
}