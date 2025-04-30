namespace Master.CQRS.Specification.Customer
{
    public class GetCustomerLocationsReadOnlySpec : Specification<DbCustomerHierarchy>
    {
        public GetCustomerLocationsReadOnlySpec(int? position, int? take)
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
