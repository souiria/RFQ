namespace Rfq.Data.Model
{
    public class DbDsiCompositeDetailCircuitOptionAssociation : IAggregateRoot
    {
        public long RowId
        { get; set; }

        public Guid CompositeDetailId
        { get; set; }

        public Guid CircuitOptionId
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
