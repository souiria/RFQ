namespace CDb.Data.Configuration.Masters
{
    public class DbFuseTypeConfiguration : IEntityTypeConfiguration<DbFuseType>
    {
        public void Configure(EntityTypeBuilder<DbFuseType> builder)
        {
            builder.ToTable("FuseTypes");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Code)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(f => f.Code)
                .IsUnique();
            builder.Property(f => f.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(f => f.IsActive)
                .IsRequired();

            // Seed initial data if necessary
            AddSeedData(builder);
        }

        static void AddSeedData(EntityTypeBuilder<DbFuseType> builder)
        {
            DbFuseType fuseTypeUnknown = new DbFuseType("Unknown", "Unknown", false);
            DbFuseType fuseTypeMicroFuse2 = new DbFuseType("MicroFuse2", "Micro fuse 2", false);
            DbFuseType fuseTypeMicroFuse3 = new DbFuseType("MicroFuse3", "Micro fuse 3", false);
            DbFuseType fuseTypeMini = new DbFuseType("Mini", "Blade fuse (mini)", false);
            DbFuseType fuseTypeATO = new DbFuseType("ATO", "Blade fuse (ato)", false);
            DbFuseType fuseTypeMAXI = new DbFuseType("MAXI", "Blade fuse (maxi)", false);
            DbFuseType fuseTypeMaxiCompactTypeL = new DbFuseType("MaxiCompactTypeL", "Maxi compact (maxi comp.L)", false);
            DbFuseType fuseTypeM8CompactTYPEM = new DbFuseType("M8CompactTYPEM", "M8C", false);
            DbFuseType fuseTypeJCASE = new DbFuseType("JCASE", "Female contact fuse (jcase)", false);
            DbFuseType fuseTypeJCASELP = new DbFuseType("JCASELP", "Female contact fuse (jcaseLP)", false);
            DbFuseType fuseTypeMCASEPLUS = new DbFuseType("MCASEPLUS", "Female contact fuse (mcase+)", false);
            DbFuseType fuseTypeMIDI = new DbFuseType("MIDI", "Screwed fuse (midi)", false);
            DbFuseType fuseTypeMEGA = new DbFuseType("MEGA", "Screwed fuse (mega)", false);
            DbFuseType fuseTypeMEGACOMPACT = new DbFuseType("MEGACOMPACT", "Screwed fuse (mega comp.)", false);

            builder.HasData(
                fuseTypeUnknown,
                fuseTypeMicroFuse2,
                fuseTypeMicroFuse3,
                fuseTypeMini,
                fuseTypeATO,
                fuseTypeMAXI,
                fuseTypeMaxiCompactTypeL,
                fuseTypeM8CompactTYPEM,
                fuseTypeJCASE,
                fuseTypeJCASELP,
                fuseTypeMCASEPLUS,
                fuseTypeMIDI,
                fuseTypeMEGA,
                fuseTypeMEGACOMPACT
            );
        }
    }
}
