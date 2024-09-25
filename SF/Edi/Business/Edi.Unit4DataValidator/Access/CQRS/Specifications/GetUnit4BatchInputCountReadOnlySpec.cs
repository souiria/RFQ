using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.CQRS.Specifications;
internal sealed class GetUnit4BatchInputCountReadOnlySpec : Specification<DbAlgBatchInput>
{
    public GetUnit4BatchInputCountReadOnlySpec(string? financeCode, string? client, string? dispatchNumber, DateTime? dispatchDate)
    {
        Query.Where(x => x.apar_id == financeCode
                         && x.client == client
                         && x.deliv_attention == dispatchNumber
                         && x.order_date == dispatchDate).AsNoTracking();
    }
}