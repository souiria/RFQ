namespace Emacs.Data.CQRS.Specification
{
    public class GetCustomerDataReadOnlySpec : Specification<DbCustomerData>
    {
        public GetCustomerDataReadOnlySpec(int? position, int? take)
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
