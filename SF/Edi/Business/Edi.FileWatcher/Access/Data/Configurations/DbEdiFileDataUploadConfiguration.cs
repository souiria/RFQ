namespace Edi.FileWatcher.Access.Data.Configurations;
internal class DbEdiFileDataUploadConfiguration : IEntityTypeConfiguration<DbEdiFileDataUpload>
{
    public void Configure(EntityTypeBuilder<DbEdiFileDataUpload> builder)
    {
        builder.ToTable("EdiFileDataUpload");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.ExchangeRate).HasColumnType("decimal(28, 4)");
        builder.Property(x => x.TotalGrossWeight).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.TotalNetWeight).HasColumnType("decimal(28, 6)");
    }
}
