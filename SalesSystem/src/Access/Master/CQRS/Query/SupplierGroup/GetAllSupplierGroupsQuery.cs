namespace Master.CQRS.Query.SupplierGroup
{
    public class GetAllSupplierGroupsQuery : IQuery<List<SupplierGroupGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
