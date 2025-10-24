namespace Master.CQRS.Specification.Customer
{
    public class GetCustomerBusinessUnitsReadOnlySpec : Specification<DbCustomerBusinessHierarchy>
    {
        public GetCustomerBusinessUnitsReadOnlySpec(int? position, int? take)
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
