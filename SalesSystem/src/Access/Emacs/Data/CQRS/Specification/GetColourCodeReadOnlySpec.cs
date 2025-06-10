namespace Emacs.Data.CQRS.Specification
{
    public class GetColourCodeReadOnlySpec : Specification<DbColourCode>
    {
        public GetColourCodeReadOnlySpec(int? position, int? take)
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
