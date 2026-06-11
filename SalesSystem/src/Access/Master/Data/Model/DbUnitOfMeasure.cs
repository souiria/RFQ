namespace Master.Data.Model
{
    public class DbUnitOfMeasure : IAggregateRoot
    {
        public string? Code
        { get; set; }

        public string? UnitOfMeasureDescription
        { get; set; }

        public bool? IsActive
        { get; set; }

        public Guid? Id
        { get; set; }

        public DateTime? CreatedDate
        { get; set; }

        public DateTime? ModifiedDate
        { get; set; }

        public Guid? CreatedBy
        { get; set; }

        public Guid? ModifiedBy
        { get; set; }

        public short? SyncToCPD
        { get; set; }
    }
}