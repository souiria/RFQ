namespace Master.CQRS.Query.Supplier
{
    public class GetAllSuppliersQuery : IQuery<List<SupplierGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
