using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.Data.Configurations;
internal class DbEdiCustomerParameterConfiguration : IEntityTypeConfiguration<DbEdiCustomerParameter>
{
    public void Configure(EntityTypeBuilder<DbEdiCustomerParameter> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)builder, "EdiCustomerParameters");
        builder.HasKey(x => x.Id);
    }
}
