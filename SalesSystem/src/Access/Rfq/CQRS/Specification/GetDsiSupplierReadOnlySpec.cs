namespace Rfq.CQRS.Specification
{
    public class GetDsiSupplierReadOnlySpec : Specification<DbDsiSupplier>
    {
        public GetDsiSupplierReadOnlySpec(int? position, int? take)
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