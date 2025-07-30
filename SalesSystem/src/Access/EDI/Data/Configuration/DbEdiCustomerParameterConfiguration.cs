namespace EDI.Data.Configuration
{
    public class DbEdiCustomerParameterConfiguration : IEntityTypeConfiguration<DbEdiCustomerParameter>
    {
        public void Configure(EntityTypeBuilder<DbEdiCustomerParameter> builder)
        {
            builder.ToTable("EdiCustomerParameters", "dbo");
            builder.HasKey(x => new { x.Id });

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Customer).HasColumnName(@"Customer").HasColumnType("varchar(max)").IsRequired().IsUnicode(false).ValueGeneratedNever();
            builder.Property(x => x.CustomerLocation).HasColumnName(@"CustomerLocation").HasColumnType("varchar(max)").IsRequired().IsUnicode(false).ValueGeneratedNever();
            builder.Property(x => x.FinanceCode).HasColumnName(@"FinanceCode").HasColumnType("varchar(max)").IsRequired().IsUnicode(false).ValueGeneratedNever();
            builder.Property(x => x.Unit4TaxCode).HasColumnName(@"Unit4TaxCode").HasColumnType("varchar(max)").IsRequired().IsUnicode(false).ValueGeneratedNever();
            builder.Property(x => x.IsAutomatingInvoices).HasColumnName(@"IsAutomatingInvoices").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IsUsingCustomerDispatchNumber).HasColumnName(@"IsUsingCustomerDispatchNumber").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IsUsingPartNumber).HasColumnName(@"IsUsingPartNumber").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.IsUsingH1CustomerOrderNumber).HasColumnName(@"IsUsingH1CustomerOrderNumber").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Unit4OrderIdStatus).HasColumnName(@"Unit4OrderIdStatus").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Unit4ProductGroup).HasColumnName(@"Unit4ProductGroup").HasColumnType("varchar(max)").IsRequired().IsUnicode(false).ValueGeneratedNever();
            builder.Property(x => x.Unit4Warehouse).HasColumnName(@"Unit4Warehouse").HasColumnType("varchar(max)").IsRequired().IsUnicode(false).ValueGeneratedNever();
            builder.Property(x => x.Unit4Client).HasColumnName(@"Unit4Client").HasColumnType("varchar(10)").IsRequired().IsUnicode(false).HasMaxLength(10).ValueGeneratedNever();
            builder.Property(x => x.IsUsingH1SchedulingAgreement).HasColumnName(@"IsUsingH1SchedulingAgreement").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.CustomerGuid).HasColumnName(@"CustomerGuid").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.CustomerLocationGuid).HasColumnName(@"CustomerLocationGuid").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.AllowZeroPrices).HasColumnName(@"AllowZeroPrices").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.CriticalPathAlert).HasColumnName(@"CriticalPathAlert").HasColumnType("bit").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.DimValue1).HasColumnName(@"Dim_Value_1").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.DimValue2).HasColumnName(@"Dim_Value_2").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.DimValue3).HasColumnName(@"Dim_Value_3").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.DimValue4).HasColumnName(@"Dim_Value_4").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.DimValue5).HasColumnName(@"Dim_Value_5").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.DimValue6).HasColumnName(@"Dim_Value_6").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.DimValue7).HasColumnName(@"Dim_Value_7").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.RelAttrId).HasColumnName(@"rel_attr_id").HasColumnType("varchar(4)").IsRequired().IsUnicode(false).HasMaxLength(4).ValueGeneratedNever();
            builder.Property(x => x.RelAttrId1).HasColumnName(@"rel_attr_id1").HasColumnType("varchar(4)").IsRequired().IsUnicode(false).HasMaxLength(4).ValueGeneratedNever();
            builder.Property(x => x.RelAttrId2).HasColumnName(@"rel_attr_id2").HasColumnType("varchar(4)").IsRequired().IsUnicode(false).HasMaxLength(4).ValueGeneratedNever();
            builder.Property(x => x.RelAttrId3).HasColumnName(@"rel_attr_id3").HasColumnType("varchar(4)").IsRequired().IsUnicode(false).HasMaxLength(4).ValueGeneratedNever();
            builder.Property(x => x.RelAttrId4).HasColumnName(@"rel_attr_id4").HasColumnType("varchar(4)").IsRequired().IsUnicode(false).HasMaxLength(4).ValueGeneratedNever();
            builder.Property(x => x.RelAttrId5).HasColumnName(@"rel_attr_id5").HasColumnType("varchar(4)").IsRequired().IsUnicode(false).HasMaxLength(4).ValueGeneratedNever();
            builder.Property(x => x.RelValue).HasColumnName(@"rel_value").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.RelValue1).HasColumnName(@"rel_value1").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.RelValue2).HasColumnName(@"rel_value2").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.RelValue3).HasColumnName(@"rel_value3").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.RelValue4).HasColumnName(@"rel_value4").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.RelValue5).HasColumnName(@"rel_value5").HasColumnType("varchar(25)").IsRequired().IsUnicode(false).HasMaxLength(25).ValueGeneratedNever();
            builder.Property(x => x.DistributionList).HasColumnName(@"DistributionList").HasColumnType("varchar(500)").IsRequired().IsUnicode(false).HasMaxLength(500).ValueGeneratedNever();
        }
    }
}
