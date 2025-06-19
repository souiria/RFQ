namespace Emacs.Data.CQRS.Specification
{
    public class GetEmacsRFIViewReadOnlySpec : Specification<DbEmacsRFIView>
    {
        public GetEmacsRFIViewReadOnlySpec(int? position, int? take)
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
