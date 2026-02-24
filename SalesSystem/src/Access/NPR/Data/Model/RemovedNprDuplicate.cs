namespace NPR.Data.Model
{
    public sealed class RemovedNprDuplicate
    {
        public Guid SetId
        { get; init; }
        public string? RfqNumber
        { get; init; }
        public string CustomerPartNumber
        { get; init; } = string.Empty;
        public string SumitomoNumber 
        { get; init; } = string.Empty;
        public RfqNprRequestModel Request
        { get; init; } = default!;

        public RemovedNprDuplicate(
            Guid setId,
            string? rfqNumber,
            string customerPartNumber,
            string sumitomoNumber,
            RfqNprRequestModel request)
        {
            SetId = setId;
            RfqNumber = rfqNumber;
            CustomerPartNumber = customerPartNumber;
            SumitomoNumber = sumitomoNumber;
            Request = request;
        }
    }
}
