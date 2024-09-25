using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.CQRS.Specifications;
internal sealed class GetUnit4AsoHeaderCountReadOnlySpec : Specification<DbUnit4SalesOrdersView>
{
    public GetUnit4AsoHeaderCountReadOnlySpec(string? financeCode, string? client, string? dispatchNumber, DateTime? dispatchDate)
    {
        Query.Where(x => x.FinanceCode == financeCode
                         && x.Client == client
                         && x.DespatchNumber == dispatchNumber
                         && x.DespatchDate == dispatchDate).OrderByDescending(x => x.ProductNumber).AsNoTracking();
    }
}
