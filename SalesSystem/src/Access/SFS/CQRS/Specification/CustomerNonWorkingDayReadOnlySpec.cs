
namespace SFS.CQRS.Specification
{
    class CustomerNonWorkingDayReadOnlySpec : Specification<DbCustomerNonWorkingDays>
    {
        public CustomerNonWorkingDayReadOnlySpec(int? position, int? take)
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
