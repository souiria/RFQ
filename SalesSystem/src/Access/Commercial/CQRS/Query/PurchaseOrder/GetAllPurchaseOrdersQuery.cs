namespace Commercial.CQRS.Query.PurchaseOrder
{
    public class GetAllPurchaseOrdersQuery : IQuery<List<PurchaseOrderDataGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
