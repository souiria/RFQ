namespace Rfq.Data.Model
{
    public class DbDsiSupplier : IAggregateRoot
    {
        public long RowId
        { get; set; }

        public string? Code
        { get; set; }

        public string? Name
        { get; set; }

        public long? SubsidiaryId
        { get; set; }

        public long? BuyerId
        { get; set; }

        public string? Address
        { get; set; }

        public string? Phone
        { get; set; }

        public string? Email
        { get; set; }

        public string? Contact
        { get; set; }

        public string? AlternateContact
        { get; set; }

        public bool? Active
        { get; set; }

        public bool? JSupplier
        { get; set; }
    }
}
