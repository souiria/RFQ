namespace SFS.CQRS.Specification
{
    public class CustomerReadOnlySpec : Specification<DbCustomer>
    {
        public CustomerReadOnlySpec(int? position, int? take)
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

