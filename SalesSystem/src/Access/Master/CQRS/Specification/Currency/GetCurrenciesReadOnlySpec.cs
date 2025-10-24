namespace Master.CQRS.Specification.Currency
{
    public class GetCurrenciesReadOnlySpec : Specification<DbCurrency>
    {
        public GetCurrenciesReadOnlySpec(int? position, int? take)
        {
            Query.Where(x => x.IsActive == true);
            if (position != null && take != null)
            {
                Query.Skip(position.Value).Take(take.Value).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
