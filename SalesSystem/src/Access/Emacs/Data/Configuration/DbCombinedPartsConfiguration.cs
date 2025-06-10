namespace Emacs.Data.Configuration
{
    public class DbCombinedPartsConfiguration : IEntityTypeConfiguration<DbCombinedParts>
    {
        public void Configure(EntityTypeBuilder<DbCombinedParts> builder)
        {
            builder.ToTable("EMACSCombinedParts");
            builder.HasKey(x => x.SumitomoNumber);
        }
    }
}
