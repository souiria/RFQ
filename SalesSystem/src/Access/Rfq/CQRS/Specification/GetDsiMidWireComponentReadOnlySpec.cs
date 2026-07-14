namespace Rfq.CQRS.Specification
{
    public class GetDsiMidWireComponentReadOnlySpec : Specification<DbDsiMidWireComponent>
    {
        public GetDsiMidWireComponentReadOnlySpec(int? position, int? take)
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