namespace Edi.Api.Access.CQRS.Specifications;
internal sealed class GetEdiCustomerParametersReadOnlySpec : Specification<DbEdiCustomerParameter>
{
    public GetEdiCustomerParametersReadOnlySpec()
    {
        Query
            .AsNoTracking();
    }
}