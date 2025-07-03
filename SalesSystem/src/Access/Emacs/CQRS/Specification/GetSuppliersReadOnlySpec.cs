namespace Emacs.CQRS.Specification
{
    public class GetSuppliersReadOnlySpec : Specification<DbSuppliers>
    {
        public GetSuppliersReadOnlySpec(int? position, int? take)
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
