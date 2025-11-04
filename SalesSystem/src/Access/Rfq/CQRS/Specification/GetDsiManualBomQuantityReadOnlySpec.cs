namespace Rfq.CQRS.Specification
{
    public class GetDsiManualBomQuantityReadOnlySpec : Specification<DbDsiManualBomQuantity>
    {
        public GetDsiManualBomQuantityReadOnlySpec(int? position, int? take)
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