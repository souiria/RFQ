namespace Edi.Unit4DataValidator.Access.CQRS.Specifications;
internal sealed class GetUnit4SalesOrdersReadOnlySpec : Specification<DbUnit4SalesOrdersView>
{
    public GetUnit4SalesOrdersReadOnlySpec(string? financeCode, string? client, string? dispatchNumber, DateTime? dispatchDate)
    {
        Query.Where(x => x.FinanceCode == financeCode
                         && x.Client == client
                         && x.DespatchNumber == dispatchNumber
                         && x.DespatchDate.Date == ((DateTime)dispatchDate).Date).OrderByDescending(x => x.ProductNumber).AsNoTracking();

    }
}
