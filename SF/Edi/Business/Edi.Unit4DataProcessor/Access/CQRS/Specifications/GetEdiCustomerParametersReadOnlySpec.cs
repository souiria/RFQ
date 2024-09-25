namespace Edi.Unit4DataProcessor.Access.CQRS.Specifications;
internal sealed class GetEdiCustomerParametersReadOnlySpec : Specification<DbEdiCustomerParameter>
{
    public GetEdiCustomerParametersReadOnlySpec()
    {
        Query
            .AsNoTracking();
    }
}