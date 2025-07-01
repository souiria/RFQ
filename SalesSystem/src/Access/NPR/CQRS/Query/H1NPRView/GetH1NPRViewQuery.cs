namespace NPR.CQRS.Query.H1NPRView
{
    public class GetH1NPRViewQuery : IQuery<List<H1NPRViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
