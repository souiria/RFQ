namespace CDb.Data.Model.Masters
{
    public class DbFileType
    {
        public Guid Id
        { get; set; }

        public string Name
        { get; set; }

        public string Description
        { get; set; }

        public bool IsActive
        { get; set; }

        public DbFileType()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;
            IsActive = false;
        }

        public DbFileType(string name, string description, bool isActive)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}