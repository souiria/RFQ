namespace Emacs.CQRS.Specification
{
    public class GetPARTMSReadOnlySpec : Specification<DbPARTMS>
    {
        public GetPARTMSReadOnlySpec(int? position, int? take)
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
