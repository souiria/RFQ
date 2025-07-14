namespace CDb.Data.Configuration.Masters
{
    public class DbClipTypeConfiguration : IEntityTypeConfiguration<DbClipType>
    {
        public void Configure(EntityTypeBuilder<DbClipType> builder)
        {
            builder.ToTable("ClipTypes");
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

        static void AddSeedData(EntityTypeBuilder<DbClipType> builder)
        {
            DbClipType clipTypeUnknown = new DbClipType("Unknown", "Unknown", false);
            DbClipType clipTypeDBL = new DbClipType("DOUBLE", "Double", false);
            DbClipType clipTypeOVALSHAPED = new DbClipType("OVALSHAPED", "Oval-Shaped", false);
            DbClipType clipTypeROUNDSHAPED = new DbClipType("ROUNDSHAPED", "Round-Shaped", false);
            DbClipType clipTypeSPT = new DbClipType("SPT", "SPT", false);
            DbClipType clipTypeTapeWrap = new DbClipType("TAPEWRAP", "Tape Wrap", false);
            DbClipType clipTypeTieWrap = new DbClipType("TIEWRAP", "Tie Wrap", false);

            builder.HasData(
                clipTypeUnknown,
                clipTypeDBL,
                clipTypeOVALSHAPED,
                clipTypeROUNDSHAPED,
                clipTypeSPT,
                clipTypeTapeWrap,
                clipTypeTieWrap
            );
        }
    }
}