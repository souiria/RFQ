namespace SFS.CQRS.Query.Period
{
   public class GetPeriodQuery : IQuery<List<PeriodViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

