
namespace Rfq.CQRS.Query
{
    public class GetDsiMidWireComponentQuery : IQuery<List<DsiMidWireComponentGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
