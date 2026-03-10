namespace Rfq.Data.Model
{
    public sealed class NprValidationResultDto
    {
        public bool AllValid
        { get; set; }
        public int ItemCount
        { get; set; }
        public int TotalQuantity
        { get; set; }

        public Dictionary<string, int> ByCustomerCounts
        { get; } = new Dictionary<string, int>();

        public Collection<NprValidationLineDto> LineStatuses
        { get; } = new Collection<NprValidationLineDto>();
    }
}
