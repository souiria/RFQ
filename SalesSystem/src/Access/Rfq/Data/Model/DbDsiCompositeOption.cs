namespace Rfq.Data.Model
{
    public class DbDsiCompositeOption : IAggregateRoot
    {
        public long RowId
        { get; set; }

        public Guid CompositeOptionId
        { get; set; }

        public string? OptionName
        { get; set; }

        public string? Description
        { get; set; }

        public Guid HarnessID
        { get; set; }

        public DateTime CreatedDate
        { get; set; }

        public DateTime? ModifiedDate
        { get; set; }

        public Guid CreatedBy
        { get; set; }

        public Guid ModifiedBy
        { get; set; }
    }
}
