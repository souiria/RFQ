namespace Emacs.Data.CQRS.Query
{
    public class GetEmacsRFIViewQuery : IQuery<List<EmacsRFIViewData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
