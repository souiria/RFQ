namespace DSI.CQRS.Specification
{
    public class GetBranchInsulationReadOnlySpec : Specification<DbBranchInsulation>
    {
        public GetBranchInsulationReadOnlySpec(int? position, int? take)
        {
            if (position != null && take != null)
            {
                Query.Skip(position.Value)
                     .Take(take.Value)
                     .AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}