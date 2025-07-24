namespace CDb.Data.Model
{
    public class DbPartNumber
    {
        public Guid Id
        { get; set; }
        public string Name
        { get; set; }
        public string? Description
        { get; set; }
        public Guid ComponentId
        { get; set; }
        public DbComponent Component
        { get; set; }
        public PartNumberType PartNumberType
        { get; set; }
        public bool IsActive
        { get; set; }

        public DbPartNumber()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            PartNumberType = PartNumberType.SUPPLIER_PN;
            Description = null;
            Component = null!;
            IsActive = false;
        }
    }
}
