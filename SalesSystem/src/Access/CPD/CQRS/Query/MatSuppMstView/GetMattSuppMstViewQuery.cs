namespace CPD.CQRS.Query.MatSuppMstView
{
    public class GetMattSuppMstViewQuery : IQuery<List<MatSuppMstViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
