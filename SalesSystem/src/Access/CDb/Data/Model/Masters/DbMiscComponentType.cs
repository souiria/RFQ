namespace CDb.Data.Model.Masters
{
    public class DbMiscComponentType
    {
        public Guid Id
        { get; set; }

        public string Code
        { get; set; }

        public string Description
        { get; set; }

        public bool IsActive
        { get; set; }

        public DbMiscComponentType()
        {
            Id = Guid.NewGuid();
            Code = string.Empty;
            Description = string.Empty;
            IsActive = false;
        }

        public DbMiscComponentType(string code, string description, bool isActive)
        {
            Id = Guid.NewGuid();
            Code = code;
            Description = description;
            IsActive = isActive;
        }
    }
}