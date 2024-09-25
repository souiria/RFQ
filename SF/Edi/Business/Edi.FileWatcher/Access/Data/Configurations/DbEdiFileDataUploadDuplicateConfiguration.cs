namespace Edi.FileWatcher.Access.Data.Configurations;
internal class DbEdiFileDataUploadDuplicateConfiguration : IEntityTypeConfiguration<DbEdiFileDataUploadDuplicate>
{
    public void Configure(EntityTypeBuilder<DbEdiFileDataUploadDuplicate> builder)
    {
        builder.ToTable("EdiFileDataUploadDuplicates");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.ExchangeRate).HasColumnType("decimal(28, 4)");
        builder.Property(x => x.TotalGrossWeight).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.TotalNetWeight).HasColumnType("decimal(28, 6)");
    }
}
