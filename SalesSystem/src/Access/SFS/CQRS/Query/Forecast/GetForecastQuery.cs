namespace SFS.CQRS.Query.Forecast
{
  public class GetForecastQuery : IQuery<List<ForecastViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

