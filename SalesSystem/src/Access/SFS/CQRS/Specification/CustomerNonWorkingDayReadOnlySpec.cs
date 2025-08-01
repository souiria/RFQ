
namespace SFS.CQRS.Specification
{
    class CustomerNonWorkingDayReadOnlySpec : Specification<DbCustomerNonWorkingDays>
    {
        public CustomerNonWorkingDayReadOnlySpec(int? position, int? take)
        {
            int maxTake = 1000;
            if (position != null && take != null)
            {
                Query.Skip(position.Value).Take(take.Value).AsNoTracking();
            }
            else
            {
                Query.Take(maxTake).AsNoTracking();
            }
        }
    }
}
