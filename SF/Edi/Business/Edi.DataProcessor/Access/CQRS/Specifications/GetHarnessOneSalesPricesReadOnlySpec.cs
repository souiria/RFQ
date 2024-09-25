namespace Edi.DataProcessor.Access.CQRS.Specifications;
internal sealed class GetHarnessOneSalesPricesReadOnlySpec : Specification<DbExternalSalesPriceInformationView>
{
    public GetHarnessOneSalesPricesReadOnlySpec()
    {
        Query.Where(x => 
                         x.StartDate < DateTime.UtcNow.Date
                         && x.EndDate > DateTime.UtcNow.Date.AddMonths(-3))
            .OrderByDescending(x => x.CreatedDate)
            .AsNoTracking();
    }
}
