namespace EDI.Data.Configuration
{
    public class DbEdiFileDataUploadDuplicateConfiguration : IEntityTypeConfiguration<DbEdiFileDataUploadDuplicate>
    {
        public void Configure(EntityTypeBuilder<DbEdiFileDataUploadDuplicate> builder)
        {
            builder.ToTable("EdiFileDataUploadDuplicates", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_EdiFileDataUploadDuplicates").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired();
            builder.Property(x => x.FileName).HasColumnName(@"FileName").HasColumnType("varchar(200)").IsRequired().IsUnicode(false).HasMaxLength(200);
            builder.Property(x => x.FinanceCode).HasColumnName(@"FinanceCode").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.UploadDate).HasColumnName(@"UploadDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DispatchNumber).HasColumnName(@"DispatchNumber").HasColumnType("varchar(200)").IsRequired().IsUnicode(false).HasMaxLength(200);
            builder.Property(x => x.DispatchDate).HasColumnName(@"DispatchDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.CustomerOrderNumber).HasColumnName(@"CustomerOrderNumber").HasColumnType("varchar(200)").IsRequired(false).IsUnicode(false).HasMaxLength(200);
            builder.Property(x => x.PartNumber).HasColumnName(@"PartNumber").HasColumnType("varchar(100)").IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.PartDescription).HasColumnName(@"PartDescription").HasColumnType("varchar(200)").IsRequired().IsUnicode(false).HasMaxLength(200);
            builder.Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("decimal(28,6)").HasPrecision(28, 6).IsRequired();
            builder.Property(x => x.UnloadingPoint).HasColumnName(@"UnloadingPoint").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.WmsSiteCode).HasColumnName(@"WMSSiteCode").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.WmsCustomerCode).HasColumnName(@"WMSCustomerCode").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.CustomerDispatchNumber).HasColumnName(@"CustomerDispatchNumber").HasColumnType("varchar(200)").IsRequired().IsUnicode(false).HasMaxLength(200);
            builder.Property(x => x.MessageType).HasColumnName(@"MessageType").HasColumnType("varchar(50)").IsRequired(false).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.ExchangeRate).HasColumnName(@"ExchangeRate").HasColumnType("decimal(28,4)").HasPrecision(28, 4).IsRequired();
            builder.Property(x => x.CustomerPartNumber).HasColumnName(@"CustomerPartNumber").HasColumnType("varchar(100)").IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.TotalGrossWeight).HasColumnName(@"TotalGrossWeight").HasColumnType("decimal(28,6)").HasPrecision(28, 6).IsRequired();
            builder.Property(x => x.TotalNetWeight).HasColumnName(@"TotalNetWeight").HasColumnType("decimal(28,6)").HasPrecision(28, 6).IsRequired();
            builder.Property(x => x.UnitofMeasure).HasColumnName(@"UnitofMeasure").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.TariffCode).HasColumnName(@"TariffCode").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.DeliveryTerms).HasColumnName(@"DeliveryTerms").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.TransportDetails).HasColumnName(@"TransportDetails").HasColumnType("varchar(100)").IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.WmsInvoiceNumber).HasColumnName(@"WMSInvoiceNumber").HasColumnType("varchar(100)").IsRequired().IsUnicode(false).HasMaxLength(100);
        }
    }
}
