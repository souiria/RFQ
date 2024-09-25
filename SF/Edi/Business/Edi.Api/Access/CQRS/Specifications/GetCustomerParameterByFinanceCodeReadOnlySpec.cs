namespace Edi.Api.Access.CQRS.Specifications;
internal sealed class GetCustomerParameterByFinanceCodeReadOnlySpec : Specification<DbEdiCustomerParameter>
{
    public GetCustomerParameterByFinanceCodeReadOnlySpec(string? financeCode)
    {
        Query
            .Where(x => x.FinanceCode == financeCode);
    }
}
