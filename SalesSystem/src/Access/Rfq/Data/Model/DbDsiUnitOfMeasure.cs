namespace Rfq.Data.Model
{
    public class DbDsiUnitOfMeasure : IAggregateRoot
    {
        public long RowId
        { get; set; }

        public string? Abbreviation
        { get; set; }

        public string? Description
        { get; set; }

        public long SubsidiaryId
        { get; set; }
    }
}
