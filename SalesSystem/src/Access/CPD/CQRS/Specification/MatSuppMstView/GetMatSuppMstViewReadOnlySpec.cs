namespace CPD.CQRS.Specification.MatSuppMstView
{
    public class GetMatSuppMstViewReadOnlySpec : Specification<DbMattSuppMstView>
    {
        public GetMatSuppMstViewReadOnlySpec(int? position, int? take)
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
