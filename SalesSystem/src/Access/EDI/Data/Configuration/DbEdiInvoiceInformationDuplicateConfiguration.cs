namespace EDI.Data.Configuration
{
    public class DbEdiInvoiceInformationDuplicateConfiguration : IEntityTypeConfiguration<DbEdiInvoiceInformationDuplicate>
    {
        public void Configure(EntityTypeBuilder<DbEdiInvoiceInformationDuplicate> builder)
        {
            builder.ToTable("EdiInvoiceInformationDuplicates", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_EdiInvoiceInformationDuplicates_1").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.FileName).HasColumnName(@"FileName").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.Customer).HasColumnName(@"Customer").HasColumnType("varchar(max)").IsRequired(false).IsUnicode(false);
            builder.Property(x => x.CustomerLocation).HasColumnName(@"CustomerLocation").HasColumnType("varchar(max)").IsRequired(false).IsUnicode(false);
            builder.Property(x => x.FinanceCode).HasColumnName(@"FinanceCode").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.DispatchNumber).HasColumnName(@"DispatchNumber").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.DispatchDate).HasColumnName(@"DispatchDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.CustomerOrderNumber).HasColumnName(@"CustomerOrderNumber").HasColumnType("varchar(max)").IsRequired(false).IsUnicode(false);
            builder.Property(x => x.PartNumber).HasColumnName(@"PartNumber").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.PartDescription).HasColumnName(@"PartDescription").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("decimal(28,6)").HasPrecision(28, 6).IsRequired();
            builder.Property(x => x.UnloadingPoint).HasColumnName(@"UnloadingPoint").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.WmsSiteCode).HasColumnName(@"WMSSiteCode").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.WmsCustomerCode).HasColumnName(@"WMSCustomerCode").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.CustomerDispatchNumber).HasColumnName(@"CustomerDispatchNumber").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.MessageType).HasColumnName(@"MessageType").HasColumnType("varchar(max)").IsRequired(false).IsUnicode(false);
            builder.Property(x => x.ExchangeRate).HasColumnName(@"ExchangeRate").HasColumnType("decimal(28,4)").HasPrecision(28, 4).IsRequired();
            builder.Property(x => x.CustomerPartNumber).HasColumnName(@"CustomerPartNumber").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.TotalGrossWeight).HasColumnName(@"TotalGrossWeight").HasColumnType("decimal(28,6)").HasPrecision(28, 6).IsRequired();
            builder.Property(x => x.TotalNetWeight).HasColumnName(@"TotalNetWeight").HasColumnType("decimal(28,6)").HasPrecision(28, 6).IsRequired();
            builder.Property(x => x.UnitofMeasure).HasColumnName(@"UnitofMeasure").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.TariffCode).HasColumnName(@"TariffCode").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.DeliveryTerms).HasColumnName(@"DeliveryTerms").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.TransportDetails).HasColumnName(@"TransportDetails").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.WmsInvoiceNumber).HasColumnName(@"WMSInvoiceNumber").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.CustomerLocationId).HasColumnName(@"CustomerLocationId").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.BatchId).HasColumnName(@"BatchId").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.IsValidPrice).HasColumnName(@"IsValidPrice").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsValidProduct).HasColumnName(@"IsValidProduct").HasColumnType("bit").IsRequired();
            builder.Property(x => x.IsProcessStarted).HasColumnName(@"IsProcessStarted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.ProcessStartDate).HasColumnName(@"ProcessStartDate").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.OrderPrice).HasColumnName(@"OrderPrice").HasColumnType("decimal(28,4)").HasPrecision(28, 4).IsRequired();
            builder.Property(x => x.CurrencyCode).HasColumnName(@"CurrencyCode").HasColumnType("varchar(max)").IsRequired().IsUnicode(false);
            builder.Property(x => x.IsAgressoTransferred).HasColumnName(@"IsAgressoTransferred").HasColumnType("bit").IsRequired();
            builder.Property(x => x.TotalInvoicePrice).HasColumnName(@"TotalInvoicePrice").HasColumnType("decimal(28,4)").HasPrecision(28, 4).IsRequired();
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProcessCompletionDate).HasColumnName(@"ProcessCompletionDate").HasColumnType("datetime2").IsRequired();
        }
    }
}
