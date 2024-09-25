namespace Edi.FileWatcher.Access.Data.Configurations;
internal class DbEdiCustomerParameterConfiguration : IEntityTypeConfiguration<DbEdiCustomerParameter>
{
    public void Configure(EntityTypeBuilder<DbEdiCustomerParameter> builder)
    {
        builder.ToTable("EdiCustomerParameters");
        builder.HasKey(x => x.Id);
    }
}
