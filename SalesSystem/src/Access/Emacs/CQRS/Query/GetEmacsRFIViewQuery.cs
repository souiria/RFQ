namespace Emacs.CQRS.Query
{
    public class GetEmacsRFIViewQuery : IQuery<List<EmacsRFIViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
