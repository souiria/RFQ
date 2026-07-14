namespace Rfq.CQRS.Specification
{
    public class GetDsiUnitOfMeasureReadOnlySpec : Specification<DbDsiUnitOfMeasure>
    {
        public GetDsiUnitOfMeasureReadOnlySpec(int? position, int? take)
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