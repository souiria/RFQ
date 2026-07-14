namespace CDb.CQRS.Specification.Masters.MaterialType
{
    public class GetMaterialTypesSpecification : Specification<DbMaterialType>
    {
        public GetMaterialTypesSpecification(int? position, int? take)
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
