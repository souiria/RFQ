namespace Master.CQRS.Specification.SupplierGroup
{
    public class GetSupplierGroupReadOnlySpec : Specification<DbSupplierGroup>
    {
        public GetSupplierGroupReadOnlySpec(int? position, int? take)
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
