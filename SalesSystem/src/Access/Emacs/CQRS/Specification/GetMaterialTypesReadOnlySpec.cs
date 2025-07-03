namespace Emacs.CQRS.Specification
{
    public class GetMaterialTypesReadOnlySpec : Specification<DbMaterialTypes>
    {
        public GetMaterialTypesReadOnlySpec(int? position, int? take)
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
