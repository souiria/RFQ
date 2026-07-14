namespace Unit4.CQRS.Specification
{
    sealed class GetUnit4AsoHeaderCountReadOnlySpec : Specification<DbUnit4SalesOrdersView>
    {
        public GetUnit4AsoHeaderCountReadOnlySpec(string? financeCode, string? client, string? dispatchNumber, DateTime? dispatchDate)
        {
            Query.Where(x => x.FinanceCode == financeCode
                             && x.Client == client
                             && x.DispatchNumber == dispatchNumber
                             && x.DispatchDate == dispatchDate).OrderByDescending(x => x.ProductNumber).AsNoTracking();
        }
    }
}
