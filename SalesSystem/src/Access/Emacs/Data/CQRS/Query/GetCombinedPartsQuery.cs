using Emacs.Data.DTOs;

namespace Emacs.Data.CQRS.Query
{
    public class GetCombinedPartsQuery : IQuery<List<CombinedPartsDto>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
