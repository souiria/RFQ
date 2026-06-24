namespace DSI.CQRS.Specification
{
    public class GetHarnessReadOnlySpec : Specification<DbHarness>
    {
        public GetHarnessReadOnlySpec(int? position, int? take)
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
