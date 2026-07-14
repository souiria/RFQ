namespace NPR.Data.Model
{
    public class DbRFQStatus : IAggregateRoot
    {
        public string? RFQStatusDescription
        { get; set; }

        public string? NPRStage
        { get; set; }
    }
}
