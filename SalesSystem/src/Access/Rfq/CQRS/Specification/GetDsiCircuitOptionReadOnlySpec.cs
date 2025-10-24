namespace Rfq.CQRS.Specification
{
    public class GetDsiCircuitOptionReadOnlySpec : Specification<DbDsiCircuitOption>
    {
        public GetDsiCircuitOptionReadOnlySpec(int? position, int? take)
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
