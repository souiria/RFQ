namespace Emacs.CQRS.Specification
{
    public class GetCombinedPartsReadOnlySpec : Specification<DbCombinedParts>
    {
        public GetCombinedPartsReadOnlySpec(int? position, int? take)
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
