namespace Edi.Unit4DataProcessor.Access.Data.Configurations;

internal class DbAlgProductInputConfiguration : IEntityTypeConfiguration<DbAlgProductInput>
{
    public void Configure(EntityTypeBuilder<DbAlgProductInput> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)builder, "algproductinput");
        builder.HasKey(x => x.agrtid);
        builder.Property(x => x.add_up).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.max_level).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.multiplier).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.order_level).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.order_val).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.overrun).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.purch_amt).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.purch_price).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.sales_amt).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.unit_value).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.value_1).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.value_from).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.value_to).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.value1).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.value2).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.value3).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.value4).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.volume).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.weight).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.min_order_qty).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.order_qty_inc).HasColumnType("decimal(28, 8)");
    }
}
