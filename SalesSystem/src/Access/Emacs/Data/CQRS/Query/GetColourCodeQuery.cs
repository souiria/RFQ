namespace Emacs.Data.CQRS.Query
{
    public class GetColourCodeQuery : IQuery<List<ColourCodeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
