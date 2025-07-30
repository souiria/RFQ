namespace CDb.CQRS.Specification.TerminalSize
{
    public class GetTerminalSizesSpecification : Specification<DbTerminalSize>
    {
        public GetTerminalSizesSpecification(int? position, int? take)
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
