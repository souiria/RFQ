namespace Rfq.Data.Model
{
    public class DbDsiScope : IAggregateRoot
    {
        public long RowId
        { get; set; }

        public string? Scope
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
