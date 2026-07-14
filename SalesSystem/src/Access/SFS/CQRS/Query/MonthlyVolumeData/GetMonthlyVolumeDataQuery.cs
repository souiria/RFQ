namespace SFS.CQRS.Query.MonthlyVolumeData
{
    public class GetMonthlyVolumeDataQuery : IQuery<List<MonthlyVolumeDataViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

