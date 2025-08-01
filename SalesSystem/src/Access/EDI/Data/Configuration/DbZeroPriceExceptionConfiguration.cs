namespace EDI.Data.Configuration
{
    public class DbZeroPriceExceptionConfiguration : IEntityTypeConfiguration<DbZeroPriceExceptions>
    {
        public void Configure(EntityTypeBuilder<DbZeroPriceExceptions> builder)
        {
            builder.ToTable("ZeroPriceExceptions", "dbo");
            builder.HasKey(x => new { x.WmsCustomerCode, x.ProductNumber }).HasName("PK_ZeroPriceExceptions").IsClustered();

            builder.Property(x => x.WmsCustomerCode).HasColumnName(@"WMSCustomerCode").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50).ValueGeneratedNever();
            builder.Property(x => x.ProductNumber).HasColumnName(@"ProductNumber").HasColumnType("varchar(500)").IsRequired().IsUnicode(false).HasMaxLength(500).ValueGeneratedNever();
        }
    }
}
