namespace Master.CQRS.Query.BusinessUnit
{
    public class GetBusinessUnitsQuery : IQuery<List<BusinessUnitGrpc>>
    {
        public int? Position
        { get; set; }

        public int? TakeAmount
        { get; set; }
    }
}
