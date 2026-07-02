namespace Commercial.CQRS.Specification
{
    public class GetAllPurchaseOrdersReadOnlySpec : Specification<DbPurchaseOrder>
    {
        public GetAllPurchaseOrdersReadOnlySpec(int? position, int? take)
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
