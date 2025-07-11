namespace SFS.CQRS.Query.DailyVolumeData
{
    public class GetDailyVolumeDataQuery : IQuery<List<DailyVolumeDataViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

