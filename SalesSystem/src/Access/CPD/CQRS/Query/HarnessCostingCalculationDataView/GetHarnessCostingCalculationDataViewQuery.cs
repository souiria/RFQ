namespace CPD.CQRS.Query.HarnessCostingCalculationDataView
{
    public class GetHarnessCostingCalculationDataViewQuery : IQuery<List<HarnessCostingCalculationDataGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
