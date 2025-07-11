namespace SFS.CQRS.Query.Period
{
   public class GetPeriodQuery : IQuery<List<PeriodListViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

