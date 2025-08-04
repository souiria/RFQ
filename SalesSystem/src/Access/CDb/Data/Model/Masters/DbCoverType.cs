namespace CDb.Data.Model.Masters
{
    public class DbCoverType : IAggregateRoot
    {
        public Guid Id
        { get; set; }
        public string Code
        { get; set; }
        public string Description
        { get; set; }
        public bool IsActive
        { get; set; }
        public DbCoverType()
        {
            Id = Guid.NewGuid();
            Code = string.Empty;
            Description = string.Empty;
            IsActive = false;
        }

        public DbCoverType(string code, string description, bool isActive)
        {
            Id = Guid.NewGuid();
            Code = code;
            Description = description;
            IsActive = isActive;
        }
    }
}