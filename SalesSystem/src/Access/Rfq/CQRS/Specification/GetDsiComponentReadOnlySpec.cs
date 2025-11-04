namespace Rfq.CQRS.Specification
{
    public class GetDsiComponentReadOnlySpec : Specification<DbDsiComponent>
    {
        public GetDsiComponentReadOnlySpec(int? position, int? take)
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
