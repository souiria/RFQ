namespace Master.CQRS.Specification.Supplier
{
    public class GetSupplierReadOnlySpec : Specification<DbSupplier>
    {
        public GetSupplierReadOnlySpec(int? position, int? take)
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
