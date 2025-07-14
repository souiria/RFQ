namespace SFS.CQRS.Specification
{
    class MonthlyVolumeDataReadOnlySpec : Specification<DbMonthlyVolumeData>
    {
        public MonthlyVolumeDataReadOnlySpec(int? position, int? take)
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
