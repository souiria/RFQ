namespace Master.CQRS.Specification.Currency
{
    public class GetCurrenciesReadOnlySpec : Specification<DbCurrency>
    {
        public GetCurrenciesReadOnlySpec(int? position, int? take)
        {
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
