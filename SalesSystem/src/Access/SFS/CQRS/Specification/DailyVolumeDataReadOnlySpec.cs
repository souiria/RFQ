namespace SFS.CQRS.Specification
{
    public class DailyVolumeDataReadonlySpec : Specification<DbDailyVolumeData>
    {
        public DailyVolumeDataReadonlySpec(int? position, int? take)
        {
            int maxTake = 1000;
            if (position != null && take != null)
            {
               
                Query.Skip(position.Value).Take(take.Value).AsNoTracking();
            }
            else
            {
                Query.Take(maxTake).AsNoTracking();
            }
        }
    }
}
