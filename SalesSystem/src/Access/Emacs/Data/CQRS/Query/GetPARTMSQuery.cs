namespace Emacs.Data.CQRS.Query
{
    public class GetPARTMSQuery : IQuery<List<PARTMSGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
