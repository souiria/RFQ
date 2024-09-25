namespace Edi.DataProcessor.Access.Data.Configurations;

internal class DbAlgBatchInputConfiguration : IEntityTypeConfiguration<DbAlgBatchInput>
{
    public void Configure(EntityTypeBuilder<DbAlgBatchInput> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)builder, "algbatchinput");
        builder.HasKey(x => x.agrtid);
        builder.Property(x => x.amount).HasColumnType("decimal(28, 3)");
        builder.Property(x => x.cur_amount).HasColumnType("decimal(28, 3)");
        builder.Property(x => x.disc_percent).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.discount).HasColumnType("decimal(28, 3)");
        builder.Property(x => x.exch_rate).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.unit_price).HasColumnType("decimal(28, 8)");
        builder.Property(x => x.value_1).HasColumnType("decimal(28, 8)");
    }
}
