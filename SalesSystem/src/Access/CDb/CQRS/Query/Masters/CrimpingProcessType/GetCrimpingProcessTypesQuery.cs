namespace CDb.CQRS.Query.Masters.CrimpingProcessType
{
    public class GetCrimpingProcessTypesQuery : IQuery<List<CrimpingProcessTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
