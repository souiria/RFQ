namespace Rfq.CQRS.Specification
{
    public class GetDsiCentreStripReadOnlySpec : Specification<DbDsiCentreStrip>
    {
        public GetDsiCentreStripReadOnlySpec(int? position, int? take)
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
