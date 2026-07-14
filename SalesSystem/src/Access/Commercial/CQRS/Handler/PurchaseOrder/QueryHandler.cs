namespace Commercial.CQRS.Handler.PurchaseOrder
{
    public class QueryHandler : IQueryHandler<GetAllPurchaseOrdersQuery, List<PurchaseOrderDataGrpc>>
    {
        readonly ICommercialReadRepository<DbPurchaseOrder> _Repository;
        List<PurchaseOrderDataGrpc> _PurchaseOrders;

        public QueryHandler(ICommercialReadRepository<DbPurchaseOrder> repository)
        {
            _Repository = repository;
            _PurchaseOrders = [];
        }

        public async Task<Result<List<PurchaseOrderDataGrpc>>> Handle(GetAllPurchaseOrdersQuery query, CancellationToken cancellationToken)
        {
            _PurchaseOrders.Clear();
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                GetAllPurchaseOrdersReadOnlySpec spec = new GetAllPurchaseOrdersReadOnlySpec(query.Position, query.TakeAmount);
                List<DbPurchaseOrder> results = await _Repository.ListAsync(spec, cts.Token);
                foreach (DbPurchaseOrder result in results)
                {
                    PurchaseOrderDataGrpc purchaseOrderDataGrpc = result.MapToPurchaseOrderDataGrpc();
                    _PurchaseOrders.Add(purchaseOrderDataGrpc);
                }

                return _PurchaseOrders;
            }
        }
    }
}
