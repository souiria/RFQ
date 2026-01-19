namespace Emacs.CQRS.Specification
{
    public class GetAlternativePartsReadOnlySpec : Specification<DbAlternativeParts> 
    {
        public GetAlternativePartsReadOnlySpec(int? position, int? take)
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
