namespace Edi.DataProcessor.Access.Data.Configurations;
internal class DbEdiFileDataUploadConfiguration : IEntityTypeConfiguration<DbEdiFileDataUpload>
{
    public void Configure(EntityTypeBuilder<DbEdiFileDataUpload> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)builder, "EdiFileDataUpload");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.ExchangeRate).HasColumnType("decimal(28, 4)");
        builder.Property(x => x.TotalGrossWeight).HasColumnType("decimal(28, 6)");
        builder.Property(x => x.TotalNetWeight).HasColumnType("decimal(28, 6)");
    }
}
