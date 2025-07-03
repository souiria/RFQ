namespace Emacs.CQRS.Specification
{
    public class GetNPASupplierReadOnlySpec : Specification<DbNPASupplier>
    {
        public GetNPASupplierReadOnlySpec(int? position, int? take)
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
