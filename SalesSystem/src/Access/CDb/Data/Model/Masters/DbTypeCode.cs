namespace CDb.Data.Model.Masters
{
    public class DbTypeCode : IAggregateRoot
    {
        public Guid Id
        { get; set; }
        public string Code
        { get; set; }
        public bool IsActive
        { get; set; }

        public DbTypeCode()
        {
            Id = Guid.NewGuid(); // Initialize with a new GUID
            Code = string.Empty; // Default value for Code
            IsActive = true; // Default value for IsActive
        }

        public DbTypeCode(string code, bool isActive = true)
        {
            Id = Guid.NewGuid();
            Code = code;
            IsActive = isActive;
        }
    }
}
